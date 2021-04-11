using MediatorBus1.Command;
using MediatorBus1.Communication;
using MediatorBus1.Event;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Extensions
{
    public static class MediatorBusExtensions
    {
        public static void AddMediatorBus(this IServiceCollection services, Type assembly)
        {
            services.AddMediatR(assembly);
            services.AddScoped<IMessageBus, MessageBus>();
            services.AddScoped<IRequestHandler<WriteInConsoleCommand, bool>, WriteInConsoleCommandHandler>();
            services.AddScoped<INotificationHandler<WriteInConsoleEvent>, WriteInConsoleEventHandler>();
            services.AddScoped<INotificationHandler<WriteInConsoleErrorEvent>, WriteInConsoleErrorEventHandler>();
        }
    }
}
