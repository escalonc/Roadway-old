using Roadway.Data.Contexts;
using Roadway.Data.Entities;

namespace Roadway.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(RoadwayContext context) : base(context)
        {
        }
    }
}
