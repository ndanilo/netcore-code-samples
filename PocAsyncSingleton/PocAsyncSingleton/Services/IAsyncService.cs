using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAsyncSingleton.Services
{
    public interface IAsyncService
    {
        Task DoWork(Func<Task> function);
    }
}
