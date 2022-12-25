using MartianRobots.Services.Implementation;
using MartianRobots.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MartianRobots
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<ICommandProcessor, CommandProcessor>()
                    .AddTransient<IInputProcessor, ConstInputProcessor>()
                    .AddTransient<IMove, RobotMoveProcessor>()
                    .AddTransient<IRotation, RobotRotation>())
            .Build();

            await host.RunAsync();
        }
    }
}