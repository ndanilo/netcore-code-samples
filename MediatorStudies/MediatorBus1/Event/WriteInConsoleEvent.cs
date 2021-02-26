using MediatorBus1.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Event
{
    public class WriteInConsoleEvent : Event
    {
        public WriteInConsoleCommand Command { get; private set; }
        public WriteInConsoleEvent(WriteInConsoleCommand command)
        {
            Command = command;
        }
    }
}
