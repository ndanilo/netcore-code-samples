using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorBus1.Command
{
    public class WriteInConsoleCommandHandler : IRequestHandler<WriteInConsoleCommand, bool>
    {
        public async Task<bool> Handle(WriteInConsoleCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{request.Message} from {request.MessageType}");
            return await Task.FromResult(true);
        }
    }
}
