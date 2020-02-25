using HR.Domain.Core.Events;
using MediatR;
using System;

namespace HR.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
