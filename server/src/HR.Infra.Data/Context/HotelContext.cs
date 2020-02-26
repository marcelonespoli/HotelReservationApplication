using HR.Domain;
using HR.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HR.Infra.Data.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooked> RoomsBooked { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelMapping());
            modelBuilder.ApplyConfiguration(new RoomMapping());
            modelBuilder.ApplyConfiguration(new RoomBookedMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
