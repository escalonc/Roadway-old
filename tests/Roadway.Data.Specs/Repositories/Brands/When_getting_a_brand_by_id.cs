using FluentAssertions;
using Machine.Specifications;
using Roadway.Data.Contexts;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;
using Roadway.Data.Specs.Contexts;

namespace Roadway.Data.Specs.Repositories.Brands
{
    class When_getting_a_brand_by_id
    {
        private static Brand _brand;
        private static Brand _selectedBrand;
        private static RoadwayContext _databaseContext;
        private static BaseRepository<Brand> _repository;

        private Establish context = async () =>
        {
            _databaseContext = new InMemoryDatabaseContextFactory().Create();
            _repository = new BrandRepository(_databaseContext);
            _brand = await _repository.Create(new Brand
            {
                Name = "Ferrari"
            });
        };

        private Because of = async () => _selectedBrand = await _repository.FindAsync(_brand.Id);

        private It should_return_the_selected_brand = () => _brand.Should().BeEquivalentTo(_selectedBrand);
    }
}