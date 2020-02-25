using HR.Domain.Core.Commands;
using System;

namespace HR.Domain.Rooms.Commands
{
    public abstract class BaseRoomBookedCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid RoomId { get; protected set; }
        public DateTime Date { get; protected set; }
    }
}
