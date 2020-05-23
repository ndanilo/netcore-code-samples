using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PocAsyncSingleton.Services
{
    public class DoSomethingService : IDoSomethingService
    {
        public string Id => Guid.NewGuid().ToString();

        public void WriteMessageAtDebug(string message, int amount)
        {
            Debug.WriteLine($"Id:{Id}");
            for (var i = 0; i < amount; i++)
            {
                Thread.Sleep(1000);
                Debug.WriteLine($"{i}:{message}");
            }
        }
    }
}
