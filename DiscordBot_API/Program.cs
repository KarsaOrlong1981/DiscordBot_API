using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace DiscordBot_API
{
    internal class Program
    {
        static DiscordClient discord;
        static int halloCount;
        static bool hallofriend;
      

       
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            halloCount = 0;
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
           

        }

       

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Discord Token eingeben: ");
            Console.BackgroundColor= ConsoleColor.Green;
            string token = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Black;
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += Discord_MessageCreated;
         
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private async static Task Discord_MessageCreated(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            if (e.Message.Content.ToLower().StartsWith("!ping"))
                await e.Message.RespondAsync("pong!");
          
            if (e.Message.Content.ToLower().StartsWith("!hallo"))
            {
                hallofriend = false;
                switch (halloCount)
                {
                    case 0: await e.Message.RespondAsync("Hallo I am ShyBot and i want to be your friend!\n Do you wan't to be my friend?"); hallofriend = true; break;
                    case 1: await e.Message.RespondAsync("are we friends now ?"); hallofriend = true; break;
                    case 2: await e.Message.RespondAsync("Yeah Hallo! We are friends ???"); hallofriend = true; break;
                    case 3: await e.Message.RespondAsync("Ok.............?!?"); break;
                    default: await e.Message.RespondAsync("........."); break;
                }
               halloCount++;
            }
            if (hallofriend == true)
            {
                if (e.Message.Content.ToLower().StartsWith("yes"))
                    await e.Message.RespondAsync("Oh, thank you! We are friends now forever! This my gift to you. https://mediafiles.mein-haustier.de/wp-content/uploads/2019/01/shutterstock_466444631-1.jpg");
                if (e.Message.Content.ToLower().StartsWith("no"))
                    await e.Message.RespondAsync("Oh, noooo. I'm so sad now. But i'm an friendly Bot and i like you https://img1.wikia.nocookie.net/__cb20090101023207/de.nintendo/images/4/47/Bowser.PNG ");
            }
            if (e.Message.Content.ToLower().StartsWith("!war"))
                await e.Message.RespondAsync("I hate War but here are all news https://www.bing.com/search?q=Krieg&form=ANSPH1&refig=c502a7ff54044d78afa4cb5347300eae&pc=U531");
            if (e.Message.Content.ToLower().StartsWith("!food"))
                await e.Message.RespondAsync("You don't know what you can eat today ? Check this out! https://www.essen-und-trinken.de/rezepte/was-koche-ich-heute");
            if (e.Message.Content.ToLower().StartsWith("!elden ring"))
                await e.Message.RespondAsync("This Game is awsome...Good luck! https://www.eurogamer.de/articles/elden-ring-komplettloesung-tipps-und-tricks");
        }
    }
}
