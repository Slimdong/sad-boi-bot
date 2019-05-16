using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;

namespace sad_boi_bot
{
    class Program
    {
        static DiscordClient discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "NTc4MDI0NzEzMTU5NDQyNDYz.XNzq1g.cKi--C7lCcP7B7PavTeCadcqnd0",
                TokenType = TokenType.Bot
            });
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Bot...");
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine("Bot successfully started.");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("WARNING: IF THE BOT IS NOT DISCONNECTED BEFORE THE CLIENT");
            Console.WriteLine("CLOSED THIS MAY CAUSE IT TO BE STUCK ONLINE ON THE SERVER!");
            Console.WriteLine("---------------------------------------------------------");
            MainMenu(true);
        }

        static async Task MainAsync(string[] args)
        {
            discord.MessageCreated += async messageCreatedEvent =>
            {
                if (messageCreatedEvent.Message.Content.ToLower().StartsWith("hey sad bot, how's it going?"))
                    await messageCreatedEvent.Message.RespondAsync("I want to ***d i e.***");
            };
        }

        static void MainMenu(bool isFirstTime)
        {
            if (!isFirstTime)
            {
                Console.Clear();
            }
            List<string> menuLayout = new List<string>()
            {
                "Type a command:",
                "   1. Connect the bot",
                "   2. Disconnect the bot",
                "   3. Manually Restart the bot",
                "   4. Quit"
            };
            foreach(var line in menuLayout)
            {
                Console.WriteLine(line);
            }
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ManualConnect();
                    MainMenu(false);
                    break;
                case "2":
                    ManualDisconnect();
                    MainMenu(false);
                    break;
                case "3":
                    ManualRestart();
                    MainMenu(false);
                    break;
                case "4":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Error: Invalid Input.");
                    Console.ReadKey();
                    MainMenu(false);
                    break;
            }
        }
        static void ManualDisconnect()
        {
            discord.DisconnectAsync();
            Console.Clear();
            Console.WriteLine("Bot Disconnected.");
            Console.ReadKey();
        }

        static void ManualConnect()
        {
            discord.ConnectAsync();
            Console.Clear();
            Console.WriteLine("Bot Connected.");
            Console.ReadKey();
        }

        static void ManualRestart()
        {
            discord.DisconnectAsync();
            discord.ConnectAsync();
            Console.Clear();
            Console.WriteLine("Bot Restarted.");
            Console.ReadKey();
        }
    }
}
