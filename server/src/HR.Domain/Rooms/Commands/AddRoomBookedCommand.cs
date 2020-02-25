using System;

namespace HR.Domain.Rooms.Commands
{
    public class AddRoomBookedCommand : BaseRoomBookedCommand
    {
        public AddRoomBookedCommand(Guid roomId, DateTime date)
        {
            var id = Guid.NewGuid();

            Id = id;
            RoomId = roomId;
            Date = date;
            AggregateId = id;
        }
    }
}
