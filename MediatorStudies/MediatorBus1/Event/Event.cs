using MediatorBus1.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorBus1.Event
{
    public abstract class Event : Message, INotification
    {
    }
}
