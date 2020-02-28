using System;

namespace HR.Domain.Rooms.Commands
{
    public class AddRoomBookedCommand : BaseRoomBookedCommand
    {
        public AddRoomBookedCommand(DateTime date)
        {
            var id = Guid.NewGuid();

            Id = id;
            Date = date;
            AggregateId = id;
        }
    }
}
