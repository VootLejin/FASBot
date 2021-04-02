using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FASBot
{
    public class IntroModule : ModuleBase<SocketCommandContext>
    {
        private readonly WeightRepo weightRepo;

        public IntroModule(
            WeightRepo weightRepo)
        {
            this.weightRepo = weightRepo;
        }

        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder][Summary("The text to echo")] string echo) => ReplyAsync(echo);

        [Command("me")]
        [Summary("Tell me your user name")]
        public Task MeAsync()
        {
            var userName = Context.User.Username;
            return ReplyAsync($"You're {userName}.");
        }

        [Command("weigh-in")]
        [Summary("Weigh in for the week")]
        public Task WeighInAsync([Remainder][Summary("Weigh in weight")] string inputWeight)
        {
            if(!double.TryParse(inputWeight, out var weight))
            {
                return ReplyAsync($"I'm sorry, I have no idea what \"{inputWeight} \" is suppopsed to mean. I'm just as confused as you are.");
            }
            var userName = Context.User.Username;
            weightRepo.Add(userName, weight);

            return ReplyAsync($"I've added {weight.ToString("0.##")} to your weight list, {userName}. Keep up the good work!");
        }

        [Command("weighin")]
        [Summary("Weigh in for the week")]
        public Task WeighInShellAsync([Remainder][Summary("Weigh in weight")] string inputWeight)
        {
            return WeighInAsync();
        }

        [Command("weights")]
        [Summary("Weights recorded")]
        public Task WeighInAsync()
        {

            var userName = Context.User.Username;

            if (!weightRepo.HasUser(userName))
            {
                return ReplyAsync($"Sorry, ${userName}, I don't seem to have any weights for you at the moment.");
            }

            var weights = weightRepo.GetWeights(userName);

            var weightsMessage = new StringBuilder();
            weightsMessage.AppendLine($"{userName} has the following weights recorded:");
            weightsMessage.AppendJoin(Environment.NewLine, weights);

            return ReplyAsync(weightsMessage.ToString());
        }
    }
}
