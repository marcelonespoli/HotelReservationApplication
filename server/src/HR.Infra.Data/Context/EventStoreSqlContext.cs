using HR.Domain.Core.Events;
using HR.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HR.Infra.Data.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
