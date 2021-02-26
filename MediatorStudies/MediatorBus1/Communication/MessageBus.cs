using MediatorBus1.Command;
using MediatorBus1.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorBus1.Communication
{
    public class MessageBus : IMessageBus
    {
        IMediator _mediator;
        public MessageBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishWriteInConsoleEvent<T>(T evt, CancellationToken ct) where T : WriteInConsoleEvent
        {
            await _mediator.Publish(evt, ct);
        }

        public async Task PublishWriteInConsoleErrorEvent<T>(T evt, CancellationToken ct) where T : WriteInConsoleErrorEvent
        {
            await _mediator.Publish(evt, ct);
        }

        public async Task<bool> SendWriteInConsoleCommand<T>(T command, CancellationToken ct) where T : WriteInConsoleCommand
        {
            return await _mediator.Send(command, ct);
        }
    }
}
