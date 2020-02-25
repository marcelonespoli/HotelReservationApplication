using System;

namespace HR.Domain.Rooms.Events
{
    public class RoomBookedAddedEvent : BaseRoomBookedEvent
    {
        public RoomBookedAddedEvent(Guid id, Guid roomId, DateTime date)
        {
            Id = id;
            RoomId = roomId;
            Date = date;
            AggregateId = id;
        }
    }
}
