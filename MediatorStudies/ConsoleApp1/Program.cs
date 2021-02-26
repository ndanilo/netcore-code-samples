using MediatorBus1.Command;
using MediatorBus1.Communication;
using MediatorBus1.Event;
using MediatorBus1.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            await ProcessCommands(host.Services);
            Console.ReadKey();
        }

        static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddMediatorBus(typeof(Program));
                });

        static async Task ProcessCommands(IServiceProvider serviceProvider)
        {
            var _messageBus = (IMessageBus)serviceProvider.GetService(typeof(IMessageBus));

            var command = new WriteInConsoleCommand
            {
                Message = "first message with mediator ..."
            };

            await _messageBus.SendWriteInConsoleCommand(command, default);

            var commandEvent = new WriteInConsoleEvent(command);

            await _messageBus.PublishWriteInConsoleEvent(commandEvent, default);
        }
    }
}
