using HR.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace HR.Domain.Rooms.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        RoomBooked GetRoomBookedById(Guid id);
        void AddRoomBooked(RoomBooked roomBooked);
        void UpdateRoomBooked(RoomBooked roomBooked);
        void RemoveRoomBooked(Guid id);
        IEnumerable<RoomBooked> GetRoomsBookedByRoomId(Guid roomId);
    }
}
