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
        static DiscordClient discord;
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            
            
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "NTc4MDI0NzEzMTU5NDQyNDYz.XNzq1g.cKi--C7lCcP7B7PavTeCadcqnd0",
                TokenType = TokenType.Bot
            });
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("Pog"))
                    await e.Message.RespondAsync("thonkeyes");
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
