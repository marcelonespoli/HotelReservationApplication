using HR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Infra.Data.Mappings
{
    public class HotelMapping : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(e => e.Address)
               .HasColumnType("varchar(350)")
               .IsRequired();

            builder.Property(e => e.City)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Phone)
               .HasColumnType("varchar(15)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Hotels");
        }
    }
}
