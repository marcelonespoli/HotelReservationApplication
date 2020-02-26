using HR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Infra.Data.Mappings
{
    public class RoomBookedMapping : IEntityTypeConfiguration<RoomBooked>
    {
        public void Configure(EntityTypeBuilder<RoomBooked> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("RoomsBooked");

            builder.HasOne(e => e.Room)
                .WithMany(c => c.RoomsBooked)
                .HasForeignKey(e => e.RoomId);
        }
    }
}
