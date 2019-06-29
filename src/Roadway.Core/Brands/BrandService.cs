using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roadway.Core.Brands.Dto;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;

namespace Roadway.Core.Brands
{
    public class BrandService : IBrandService
    {
        private readonly BaseRepository<Brand> _brandRepository;

        public BrandService(BaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task Create(CreateBrand entity)
        {
            var brand = new Brand
            {
                Name = entity.Name
            };

            await _brandRepository.Create(brand);
        }

        public async Task Delete(int id)
        {
            var entity = await _brandRepository.FindAsync(id);
            await _brandRepository.Delete(entity);
        }

        public async Task<IEnumerable<GetBrand>> All(int page, int size)
        {
            return await _brandRepository.All(page, size).Select(brand => new GetBrand
            {
                Id = brand.Id,
                Name = brand.Name
            }).ToListAsync();
        }

        public async Task<GetBrand> FindById(int id)
        {
            var brand = await _brandRepository.FindAsync(id);
            return new GetBrand
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        public async Task Update(EditBrand entity)
        {
            var brand = new Brand
            {
                Id = entity.Id,
                Name = entity.Name
            };
            
            await _brandRepository.Update(brand);
        }
    }
}