using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roadway.Infrastructure.Pagination
{
    public interface IPageable<T>
    {
        Task<IEnumerable<T>> Paginate(PageConfiguration options);
    }
}
