using System;
using System.Collections.Generic;

namespace HR.Domain.Rooms.Commands
{
    public class CreateRoomCommand : BaseRoomCommand
    {
        public ICollection<AddRoomBookedCommand> RoomsBooked { get; private set; }

        public CreateRoomCommand(Guid id, string name, Guid hotelId, ICollection<AddRoomBookedCommand> roomsBooked)
        {
            Id = id;
            Name = name;
            HotelId = hotelId;
            RoomsBooked = roomsBooked;
            AggregateId = id;
        }
    }
}
