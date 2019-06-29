using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roadway.Core.Common
{
    public interface IMaintainable<TGet, in TCreate, in TEdit, in TKey>
    {
        Task Create(TCreate entity);

        Task<TGet> FindById(TKey id);

        Task<IEnumerable<TGet>> All(int page, int size);

        Task Update(TEdit entity);

        Task Delete(TKey id);

    }
}