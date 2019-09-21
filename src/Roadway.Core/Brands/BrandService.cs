using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roadway.Core.Brands.Dto;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;
using Roadway.Infrastructure.Pagination;

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

        public async Task Remove(int id)
        {
            var entity = await _brandRepository.FindAsync(id);
            await _brandRepository.Delete(entity);
        }

        public async Task<IEnumerable<GetBrand>> FindAll(int page, int size)
        {
            return await _brandRepository.All().Page(page, size).Select(brand => new GetBrand
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

        public async Task<PaginationResponseModel<GetBrand>> Search(string searchTerm, int page, int size)
        {
            var data = await _brandRepository
                .Filter(brand => brand.Name.Contains(searchTerm))
                .Page(page, size)
                .Select(brand => new GetBrand
                {
                    Id = brand.Id,
                    Name = brand.Name
                })
                .ToListAsync();

            return new PaginationResponseModel<GetBrand> { Data= data, TotalCount= _brandRepository.All().Count()};
        }
    }
}