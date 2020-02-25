using System;
using System.Collections.Generic;

namespace HR.Domain.Rooms.Events
{
    public class RoomCreatedEvent : BaseRoomEvent
    {
        public ICollection<RoomBookedAddedEvent> RoomsBooked { get; private set; }

        public RoomCreatedEvent(Guid id, string name, Guid hotelId, ICollection<RoomBookedAddedEvent> roomsBooked)
        {
            Id = id;
            Name = name;
            HotelId = hotelId;
            RoomsBooked = roomsBooked;
            AggregateId = id;
        }
    }
}
