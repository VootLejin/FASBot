using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace FASBot
{
    public class WeightLossModule : ModuleBase<SocketCommandContext>
    {
        [Command("record")]
        [Summary("Records weight of user")]
        public async Task RecordWeightAsync(
            [Summary("User's Current Weight")] decimal weight,
            [Summary("The (optional) user to get info from")]
            SocketUser user = null)
        {
            var userInfo = user ?? this.Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username} recorded {weight.ToString("0.##")}");
        }
    }
}
