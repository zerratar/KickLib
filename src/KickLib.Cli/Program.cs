// See https://aka.ms/new-console-template for more information

Console.WriteLine("KickLib - Command Line Interface");

using var client = new KickLib.KickClient();

client.ChatMessageReceived += OnChatMessageReceived;

Console.WriteLine("Initializing... Please wait");
await client.InitializeAsync();

do
{
    Console.Write("Please enter a live channel: ");
    var targetChannel = Console.ReadLine();
    var result = await ConnectToChatAsync(targetChannel);
    if (result == ChannelConnectResult.Success)
    {
        break;
    }

    if (result == ChannelConnectResult.NotLive)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That channel is not live.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That channel does not exist.");
    }

    Console.ResetColor();
} while (true);

Console.ReadKey();

async Task<ChannelConnectResult> ConnectToChatAsync(string username)
{
    //var emotes = await client.GetEmotesAsync();
    Console.WriteLine("Loading channel data for " + username);
    var channel = await client.GetChannelAsync(username);

    if (channel == null || channel.User == null)
    {
        return ChannelConnectResult.DoesNotExist;
    }

    if (channel.Livestream == null || !channel.Livestream.IsLive)
    {
        return ChannelConnectResult.NotLive;
    }

    Console.WriteLine("Connecting to chat...");
    await client.ConnectAsync(channel);

    return ChannelConnectResult.Success;
}


void OnChatMessageReceived(object? sender, KickLib.ChatMessageReceivedEventArgs e)
{
    var msg = e.Message;
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {{chatroom.{msg.Message.ChatroomId}}} " + msg.User.Username + ": " + msg.Message.Content);
}

enum ChannelConnectResult
{
    NotLive,
    DoesNotExist,
    Success
}
