using System;
using System.Collections.Generic;
using System.Text;

namespace Roadway.Infrastructure.Pagination
{
    public class PaginationResponseModel<T>
    {
        public List<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}
