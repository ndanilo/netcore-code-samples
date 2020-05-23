using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAsyncSingleton.Services
{
    public interface IDoSomethingService
    {
        string Id { get; }
        void WriteMessageAtDebug(string message, int amount);
    }
}
