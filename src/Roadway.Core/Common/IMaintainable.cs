using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roadway.Core.Common
{
    public interface IMaintainable<TEntity, TKey>
    {
        Task Create(TEntity entity);

        Task<TEntity> FindById(TKey id);

        Task Update(TEntity entity);

        Task Delete(TKey id);

    }
}
