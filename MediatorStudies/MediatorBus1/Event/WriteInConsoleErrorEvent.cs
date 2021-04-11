using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Event
{
    public class WriteInConsoleErrorEvent : Event
    {
        public Exception Exception { get; private set; }
        public WriteInConsoleErrorEvent(Exception exception)
        {
            Exception = exception;
        }
    }
}
