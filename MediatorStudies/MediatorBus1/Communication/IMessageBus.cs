using MediatorBus1.Command;
using MediatorBus1.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorBus1.Communication
{
    public interface IMessageBus
    {
        Task<bool> SendWriteInConsoleCommand<T>(T command, CancellationToken ct) where T : WriteInConsoleCommand;
        Task PublishWriteInConsoleEvent<T>(T evt, CancellationToken ct) where T : WriteInConsoleEvent;
        Task PublishWriteInConsoleErrorEvent<T>(T evt, CancellationToken ct) where T : WriteInConsoleErrorEvent;
    }
}
