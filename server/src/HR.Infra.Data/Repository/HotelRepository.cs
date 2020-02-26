using Dapper;
using HR.Domain;
using HR.Domain.Hotels.Repository;
using HR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Infra.Data.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelContext context) : base(context)
        {
        }

        // Used Dapper package for some queries
        // Dapper can have more query performance than the EF

        public override IEnumerable<Hotel> GetAll()
        {
            var sql = @"SELECT * FROM Hotels H " +
                      "ORDER BY H.Name ";

            return Db.Database.GetDbConnection().Query<Hotel>(sql);
        }

        public override Hotel GetById(Guid id)
        {
            var sql = @"SELECT * FROM Hotels H " +
                       "WHERE H.Id = @uid";

            var hotel = Db.Database.GetDbConnection().Query<Hotel>(sql, new { uid = id });

            return hotel.SingleOrDefault();
        }
    }
}
