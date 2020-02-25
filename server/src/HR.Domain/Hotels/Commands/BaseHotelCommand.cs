using HR.Domain.Core.Commands;
using System;

namespace HR.Domain.Hotels.Commands
{
    public abstract class BaseHotelCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string Phone { get; protected set; }
        public int Stars { get; protected set; }
    }
}
