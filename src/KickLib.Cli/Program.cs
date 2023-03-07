// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;
using System.Net;

Console.WriteLine("KickLib  - Command Line Interface");

using var client = new KickLib.KickClient("adinross");
await client.InitializeAsync();

var emotes = await client.GetEmotesAsync();

//await page.ScreenshotAsync("screen.png");


Console.ReadKey();
