using Roadway.Data.Contexts;
using Roadway.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadway.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(RoadwayContext context) : base(context)
        {
        }
    }
}
