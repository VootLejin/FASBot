using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Discord.Net.Rest;
using Discord.Rest;

namespace FASBot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var prog = new FasBotFramework(); 
            await prog.MainAsync();
        }
    }
}
