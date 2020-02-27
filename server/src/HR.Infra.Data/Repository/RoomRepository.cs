using Dapper;
using HR.Domain;
using HR.Domain.Rooms.Repository;
using HR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Infra.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelContext context) : base(context)
        {
        }

        // Used Dapper package for some queries
        // Dapper can have more query performance than the EF

        public override IEnumerable<Room> GetAll()
        {
            var sql = @"SELECT * FROM Rooms R " +
                      "ORDER BY R.Name ";

            return Db.Database.GetDbConnection().Query<Room>(sql);
        }

        public override Room GetById(Guid id)
        {
            var sql = @"SELECT * FROM Rooms R " +
                       "WHERE R.Id = @uid";

            var room = Db.Database.GetDbConnection().Query<Room>(sql, new { uid = id });

            return room.SingleOrDefault();
        }

        public RoomBooked GetRoomBookedById(Guid id)
        {
            var sql = @"SELECT * FROM RoomsBooked RB " +
                       "WHERE RB.Id = @uid";

            var subtask = Db.Database.GetDbConnection().Query<RoomBooked>(sql, new { uid = id });

            return subtask.SingleOrDefault();
        }

        public IEnumerable<RoomBooked> GetRoomsBookedByRoomId(Guid roomId)
        {
            var sql = @"SELECT * FROM RoomsBooked RB " +
                       "WHERE RB.RoomId = @rid " +
                       "ORDER BY RB.Date";

            return Db.Database.GetDbConnection().Query<RoomBooked>(sql, new { rid = roomId });
        }

        public void AddRoomBooked(RoomBooked roomBooked)
        {
            Db.RoomsBooked.Add(roomBooked);
        }

        public void UpdateRoomBooked(RoomBooked roomBooked)
        {
            Db.RoomsBooked.Update(roomBooked);
        }

        public void RemoveRoomBooked(Guid id)
        {
            Db.RoomsBooked.Remove(Db.RoomsBooked.Find(id));
        }
    }
}
