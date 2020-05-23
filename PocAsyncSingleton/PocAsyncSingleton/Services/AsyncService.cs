using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAsyncSingleton.Services
{
    public class AsyncService : IAsyncService
    {
        public async Task DoWork(Func<Task> function)
        {    
            await function();
        }
    }
}
