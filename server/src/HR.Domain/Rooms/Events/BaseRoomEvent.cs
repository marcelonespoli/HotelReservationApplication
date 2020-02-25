using HR.Domain.Core.Events;
using System;

namespace HR.Domain.Rooms.Events
{
    public abstract class BaseRoomEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid HotelId { get; protected set; }
    }
}
