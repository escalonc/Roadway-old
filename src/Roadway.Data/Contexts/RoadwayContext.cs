using Microsoft.EntityFrameworkCore;
using Roadway.Data.Entities;

namespace Roadway.Data.Contexts
{
    public class RoadwayContext : DbContext
    {
        public RoadwayContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
    }
}