using KickLib.Models;
using PusherClient;

namespace KickLib
{
    public class KickAppKeys
    {
        // note these values are better fetched in the initialize state.

        public static string VITE_APP_URL = "https://kick.com";
        public static string VITE_RECAPTCHA_SITE_KEY = "6LfW60MjAAAAAKJlV_IW6cYl63zpKNuI4EMkxR9b";
        public static string VITE_PUSHER_APP_KEY = "eb1d5f283081a78b932c";
        public static string VITE_PUSHER_APP_CLUSTER = "us2";
        public static string BASE_URL = "https://dbxmjjzl5pc1g.cloudfront.net/c28817ac-d0f8-4f25-9b16-7c1565e46720/build/";
    }

    public class KickChatClient : IDisposable
    {
        private readonly KickClient apiClient;

        // wss://ws-us2.pusher.com/app/eb1d5f283081a78b932c?protocol=7&client=js&version=7.4.0&flash=false

        //stats.pusher.com
        // See javascript object: Echo in the console

        private readonly Pusher pusher;
        private List<Channel> subscribedChannels = new List<Channel>();

        public KickChatClient(KickClient apiClient)
        {
            this.apiClient = apiClient;
            // Create Pusher client ready to subscribe to public, private and presence channels
            this.pusher = new Pusher(KickAppKeys.VITE_PUSHER_APP_KEY, new PusherOptions
            {
                Authorizer = apiClient,
                Host = "stats.pusher.com",
                Cluster = KickAppKeys.VITE_PUSHER_APP_CLUSTER,
                //Encrypted = true,
            });

            this.pusher.BindAll(OnPusherEvent);
            this.pusher.Error += OnError;
            this.pusher.Disconnected += OnDisconnected;
            this.pusher.Connected += OnConnected;
        }

        private void OnPusherEvent(string eventName, PusherEvent eventData)
        {
            switch (eventName)
            {
                case "App\\Events\\ChatMessageDeletedEvent":
                    apiClient.OnChatMessageDeleted(Newtonsoft.Json.JsonConvert.DeserializeObject<DeletedChatMessage>(eventData.Data) ?? new DeletedChatMessage());
                    return;
                case "App\\Events\\ChatMessageSentEvent":
                    apiClient.OnChatMessageReceived(Newtonsoft.Json.JsonConvert.DeserializeObject<ChatMessage>(eventData.Data) ?? new ChatMessage());
                    return;
            }

            Console.WriteLine(
                "Unhandled Event Received: " + eventName +
                ", channel: '" + eventData.ChannelName +
                "', user: '" + eventData.UserId +
                "', data: " + eventData.Data);
        }

        private void OnError(object sender, PusherException error)
        {
            Console.WriteLine("Pusher Error: " + error);
        }

        private void OnDisconnected(object sender)
        {
            Console.WriteLine("Disconnected from Kick Pusher");
        }

        private void OnConnected(object sender)
        {
            Console.WriteLine("Connected to Kick Pusher");
        }

        public void Dispose()
        {
            pusher.DisconnectAsync();
        }


        internal async Task DisconnectAsync()
        {
            if (subscribedChannels.Count == 0 || pusher.State != ConnectionState.Connected)
            {
                return;
            }

            subscribedChannels.Clear();
            await pusher.UnsubscribeAllAsync();
            await pusher.DisconnectAsync();
        }

        internal async Task DisconnectAsync(KickChannel channel)
        {
            if (subscribedChannels.Count == 0 || pusher.State != ConnectionState.Connected)
            {
                return;
            }

            var targetChannelName = "chatrooms." + channel.ChatRoom.Id;
            var sub = subscribedChannels.FirstOrDefault(x => x.Name == targetChannelName);
            if (sub == null)
            {
                return;
            }

            await pusher.UnsubscribeAsync(targetChannelName);
            subscribedChannels.Remove(sub);

            if (subscribedChannels.Count == 0)
            {
                await pusher.DisconnectAsync();
            }
        }


        internal async Task ConnectAsync(KickChannel channel)
        {
            if (pusher.State == ConnectionState.Uninitialized || pusher.State == ConnectionState.Disconnected)
            {
                await pusher.ConnectAsync();
            }

            var targetChannelName = "chatrooms." + channel.ChatRoom.Id;
            if (subscribedChannels.Any(x => x.Name == targetChannelName))
            {
                // we are already subscribed.
                return;
            }

            subscribedChannels.Add(await pusher.SubscribeAsync(targetChannelName));
        }

        private readonly PusherChannel[] AvailableChannels = new PusherChannel[] {
            new PusherChannel(ChannelTypes.Private, "userfeed"),
            new PusherChannel(ChannelTypes.Private, "App.User"),
            new PusherChannel(ChannelTypes.Private, "livestream"),
            new PusherChannel(ChannelTypes.Private, "chatrooms"),
        };

        private class PusherChannel
        {
            public ChannelTypes Type { get; set; }
            public string Name { get; set; }
            public string Id { get; set; }

            public PusherChannel() { }
            public PusherChannel(ChannelTypes type, string name)
            {
                Type = type;
                Name = name;
            }

            public string Resolve(string id)
            {
                return Type.ToString().ToLower() + "-" + Name + "." + id;
            }

            public override string ToString()
            {
                if (!string.IsNullOrEmpty(Id))
                    return Type.ToString().ToLower() + "-" + Name + "." + Id;
                return Type.ToString().ToLower() + "-" + Name + ".{id}";
            }
        }
    }

}