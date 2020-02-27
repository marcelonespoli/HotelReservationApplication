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

        public IEnumerable<Room> GetRoomsByHotelId(Guid hotelId)
        {
            return Search(x => x.HotelId == hotelId);
        }

        public IEnumerable<Room> GetRoomsAvailablePerPeriod(Guid hotelId, DateTime startDate, DateTime endDate)
        {
            return (from h in Db.Hotels
                         join r in Db.Rooms on h.Id equals r.HotelId
                         where r.HotelId == hotelId
                         select r).ToList();

            //var availability = (from rb in Db.RoomsBooked
            //                    join r in Db.Rooms on rb.RoomId equals 
            //                    select r.Id);

            //return (from h in Db.Hotels
            //        join r in Db.Rooms on h.Id equals r.HotelId
            //        join rb in Db.RoomsBooked on r.Id equals rb.RoomId
            //        where h.Id == hotelId &&
            //              r.Id != (from x in Db.RoomsBooked where x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date select x.RoomId)
                           
            //        group r by new { r.Id, r.Name, r.HotelId } into g
            //        select new Room(g.Key.Id, g.Key.Name, g.Key.HotelId));
        }
    }
}

// !(rb.Date >= startDate && rb.Date <= endDate)