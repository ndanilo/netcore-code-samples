using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Command
{
    public class WriteInConsoleCommand : Command
    {
        public string Message { get; set; }
    }
}
