using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAsyncSingleton.Services
{
    public class AsyncService : IAsyncService
    {
        private readonly IDoSomethingService _service;
        public AsyncService(IDoSomethingService service)
        {
            _service = service;
        }
        public async Task DoWork(string message, int amount)
        {
            await Task.Run(() => _service.WriteMessageAtDebug(message, amount));
        }
    }
}
