using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Core
{
    public abstract class Message
    {
        public string MessageType { get; private set; }
        public Message()
        {
            MessageType = GetType().FullName;
        }
    }
}
