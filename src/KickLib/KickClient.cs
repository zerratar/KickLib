using KickLib.Models;
using PuppeteerSharp;
using PusherClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;

namespace KickLib
{
    public class KickClient : IAuthorizer, IDisposable
    {
        private HttpClientHandler httpClientHandler;
        private HttpClient httpClient;

        private readonly CookieContainer reqCookieContainer = new CookieContainer();
        private readonly Dictionary<string, string> reqHeaders = new Dictionary<string, string>();
        private readonly KickChatClient chatClient;

        public event EventHandler<ChatMessageReceivedEventArgs> ChatMessageReceived;
        public event EventHandler<ChatMessageDeletedEventArgs> ChatMessageDeleted;

        public KickClient()
        {
            httpClientHandler = new HttpClientHandler() { CookieContainer = reqCookieContainer };
            httpClient = new HttpClient(httpClientHandler);
            httpClient.BaseAddress = new Uri("https://kick.com");
            chatClient = new KickChatClient(this);
        }

        public async Task ConnectAsync(KickChannel channel)
        {
            await chatClient.ConnectAsync(channel);
        }

        public async Task DisconnectAsync(KickChannel channel)
        {
            await chatClient.DisconnectAsync(channel);
        }

        public string Authorize(string channelName, string socketId)
        {
            return RequestPusherAuthTokenAsync(channelName, socketId).Result.Auth;
        }

        public async Task<PusherAuthTokenResponse> RequestPusherAuthTokenAsync(string channelName, string socketId)
        {
            // https://kick.com/broadcasting/auth

            var result = await httpClient.PostAsync("/broadcasting/auth", JsonContent.Create(new
            {
                socket_id = socketId,
                channel_name = channelName
            }));

            var content = await result.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PusherAuthTokenResponse>(content);
        }

        internal void OnChatMessageReceived(ChatMessage msg)
        {
            var evt = ChatMessageReceived;
            if (evt != null)
            {
                evt.Invoke(this, new ChatMessageReceivedEventArgs(msg));
            }
        }

        internal void OnChatMessageDeleted(DeletedChatMessage msg)
        {
            var evt = ChatMessageDeleted;
            if (evt != null)
            {
                evt.Invoke(this, new ChatMessageDeletedEventArgs(msg));
            }
        }

        public async Task<KickChannel> GetChannelAsync(string targetUser)
        {
            // https://kick.com/api/v1/channels/lospollostv
            try
            {
                var json = await httpClient.GetStringAsync("/api/v1/channels/" + targetUser);
                if (string.IsNullOrEmpty(json)) return new KickChannel();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<KickChannel>(json);
            }
            catch
            {
                return new KickChannel();
            }
        }

        public async Task<EmoteSource[]> GetEmotesAsync(string targetUser)
        {
            try
            {
                var emotesJson = await httpClient.GetStringAsync("/emotes/" + targetUser);
                if (string.IsNullOrEmpty(emotesJson)) return new EmoteSource[0];
                return Newtonsoft.Json.JsonConvert.DeserializeObject<EmoteSource[]>(emotesJson);
            }
            catch
            {
                return new EmoteSource[0];
            }
        }

        public async Task InitializeAsync()
        {
            //var response = await httpClient.GetAsync("/");
            //var status = response.StatusCode;
            var tss = new TaskCompletionSource<bool>();
            var targetUrl = "https://kick.com/";// + targetUser;

            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions { Headless = true });
            await using var page = await browser.NewPageAsync();
            page.Request += OnRequest;

            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.87 Safari/537.36");
            await page.SetJavaScriptEnabledAsync(true);
            await page.GoToAsync(targetUrl, WaitUntilNavigation.DOMContentLoaded);

            async void OnRequest(object? sender, RequestEventArgs e)
            {
                var headers = e.Request.Headers;

                if (headers.TryGetValue("Referer", out var value) && value == targetUrl)
                {
                    // scrape headers and get cookies.

                    // we will use this for normal web requests

                    var cookies = await page.GetCookiesAsync();

                    lock (reqCookieContainer)
                    {
                        if (tss.Task.IsCompleted)
                        {
                            return;
                        }

                        if (reqCookieContainer.Count == 0)
                        {
                            if (cookies.Length > 0)
                            {
                                foreach (var header in headers)
                                {
                                    reqHeaders[header.Key] = header.Value;
                                }

                                foreach (var cookie in cookies)
                                {
                                    reqCookieContainer.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                                }

                                tss.SetResult(true);
                            }
                        }
                    }
                }
            }

            await tss.Task;

            //var echo = await page.EvaluateExpressionAsync<object>("window.Echo");

            httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in reqHeaders)
            {
                if (!httpClient.DefaultRequestHeaders.Contains(header.Key))
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public void Dispose()
        {
            chatClient.Dispose();
            httpClientHandler.Dispose();
            httpClient.Dispose();
        }
    }
}