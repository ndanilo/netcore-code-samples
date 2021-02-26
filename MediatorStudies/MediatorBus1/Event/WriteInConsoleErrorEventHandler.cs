using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorBus1.Event
{
    public class WriteInConsoleErrorEventHandler : INotificationHandler<WriteInConsoleErrorEvent>
    {
        public async Task Handle(WriteInConsoleErrorEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{notification.Exception.Message}");
            await Task.CompletedTask;
        }
    }
}
