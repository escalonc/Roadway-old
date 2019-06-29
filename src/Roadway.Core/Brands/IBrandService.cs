using Roadway.Core.Common;
using Roadway.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Roadway.Core.Brands.Dto;

namespace Roadway.Core.Brands
{
    public interface IBrandService: IMaintainable<GetBrand, CreateBrand, EditBrand, int>
    {
    }
}
