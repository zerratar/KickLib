# KickLib
A .NET API Client for the streaming service kick.com to allow writing chatbots and interact with their services (in development)


## How to use

You can check tthe KickLib.Cli project as an example for how to use the library. Its still very experimental and the API may change at any time.

Currently Reading Channel details, Available Emotes and Chat Messages are available.

```cs

var username = "kick_streamer_username_here";

using(var client = new KickLib.KickClient())
{
    // Initialize will start the headless Chromium to fetch necessary cookies and tokens for any upcoming requests
    await client.InitializeAsync();

    client.ChatMessageReceived += (sender, e) =>
    {
        var msg = e.Message;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {{chatroom.{msg.Message.ChatroomId}}} " + msg.User.Username + ": " + msg.Message.Content);
    };

    var channel = await client.GetChannelAsync(username);
    if (channel != null) 
    {
        // you can connect to as many channels as you want with the same client.
        await client.ConnectAsync(channel);
    }
}

Console.ReadKey();
```