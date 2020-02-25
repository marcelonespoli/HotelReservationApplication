using HR.Domain.Core.Commands;
using System;

namespace HR.Domain.Rooms.Commands
{
    public abstract class BaseRoomCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid HotelId { get; protected set; }
    }
}
