using Microsoft.EntityFrameworkCore;
using Roadway.Data.Contexts;

namespace Roadway.Data.Specs.Contexts
{
    public class InMemoryDatabaseContextFactory
    {
        public RoadwayContext Create()
        {
            var options = new DbContextOptionsBuilder<RoadwayContext>()
                .UseInMemoryDatabase(databaseName: "RoadwayTest")
                .Options;
            var dbContext = new RoadwayContext(options);

            return dbContext;
        }
    }
}
