using MediatorBus1.Communication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorBus1.Event
{
    public class WriteInConsoleEventHandler : INotificationHandler<WriteInConsoleEvent>
    {
        private readonly IMessageBus _messageBus;
        public WriteInConsoleEventHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        public async Task Handle(WriteInConsoleEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"EVENT: {notification.Command.MessageType} from {notification.MessageType}");

            var errorEvt = new WriteInConsoleErrorEvent(new Exception("forced exception!!"));

            await _messageBus.PublishWriteInConsoleErrorEvent(errorEvt, default);
            await Task.CompletedTask;
        }
    }
}
