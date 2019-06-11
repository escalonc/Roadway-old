using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;

namespace Roadway.Core.Brands
{
    public class BrandService : IBrandService
    {
        private readonly BaseRepository<Brand> brandRepository;

        public BrandService(BaseRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task Create(Brand entity)
        {
            await this.brandRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await this.FindById(id);
            await this.brandRepository.Delete(entity);
        }

        public async Task<Brand> FindById(int id)
        {
            return await this.brandRepository.FindAsync(id);
        }

        public async Task Update(Brand entity)
        {
            await this.brandRepository.Update(entity);
        }
    }
}
