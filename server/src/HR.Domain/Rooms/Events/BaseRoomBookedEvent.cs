using HR.Domain.Core.Events;
using System;

namespace HR.Domain.Rooms.Events
{
    public abstract class BaseRoomBookedEvent : Event
    {
        public Guid Id { get; protected set; }
        public Guid RoomId { get; protected set; }
        public DateTime Date { get; protected set; }
    }
}
