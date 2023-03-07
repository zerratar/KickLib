// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;
using System.Net;

Console.WriteLine("KickLib  - Command Line Interface");

var targetUser = "lospollostv";
using var client = new KickLib.KickClient(targetUser);

client.ChatMessageReceived += OnChatMessageReceived;

Console.WriteLine("Initializing... Please wait");
await client.InitializeAsync();

//var emotes = await client.GetEmotesAsync();
Console.WriteLine("Loading channel data for " + targetUser);
var channel = await client.GetChannelAsync();

Console.WriteLine("Connecting to chat...");
await client.ConnectAsync(channel);

//client.OnChatMessageReceived

Console.ReadKey();


void OnChatMessageReceived(object? sender, KickLib.ChatMessageReceivedEventArgs e)
{
    var msg = e.Message;
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {{chatroom.{msg.Message.ChatroomId}}} " + msg.User.Username + ": " + msg.Message.Content);

}
