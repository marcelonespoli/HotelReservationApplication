using HR.Domain.Core.Events;
using System;

namespace HR.Domain.Hotels.Events
{
    public abstract class BaseHotelEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string Phone { get; protected set; }
        public int Stars { get; protected set; }
    }
}
