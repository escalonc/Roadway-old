using System.Linq;
using Microsoft.EntityFrameworkCore;
using Roadway.Data.Entities;

namespace Roadway.Data.Contexts
{
    public class RoadwayContext : DbContext
    {
        public RoadwayContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(entity => typeof(BaseEntity).IsAssignableFrom(entity.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Disabled")
                    .HasDefaultValue(false);
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}