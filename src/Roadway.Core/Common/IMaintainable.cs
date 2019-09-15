using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roadway.Core.Common
{
    public interface IMaintainable<TGet, in TCreate, in TEdit, in TKey>
    {
        Task Create(TCreate entity);


        Task<TGet> FindById(TKey id);

        Task<IEnumerable<TGet>> FindAll(int page, int size);

        Task<IEnumerable<TGet>> Search(string searchTerm, int page, int size);

        Task Update(TEdit entity);

        Task Remove(TKey id);

    }
}