using System.Linq;
using FluentAssertions;
using Machine.Specifications;
using Roadway.Data.Contexts;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;
using Roadway.Data.Specs.Contexts;

namespace Roadway.Data.Specs.Repositories.Brands
{
    public class When_creating_a_new_brand
    {
        private static RoadwayContext _databaseContext;
        private static BaseRepository<Brand> _repository;
        private static int _brandsCount;

        private Establish context = () =>
        {
            _databaseContext = new InMemoryDatabaseContextFactory().Create();
            _repository = new BrandRepository(_databaseContext);
        };

        private Because of = async () =>
        {
            await _repository.Create(new Brand
            {
                Name = "Toyota"
            });

            _brandsCount = _repository.All().Count();
        };

        private Cleanup after = () => _databaseContext.Database.EnsureDeleted();

        It should_contains_at_least_one_element = () =>  _brandsCount.Should().Be(1);
    }

    class When_removing_a_brand
    {
        private static Brand _brand;
        private static Brand _disabledBrand;
        private static RoadwayContext _databaseContext;
        private static BaseRepository<Brand> _repository;
        
        private Establish context = async () =>
        {
            _databaseContext = new InMemoryDatabaseContextFactory().Create();
            _repository = new BrandRepository(_databaseContext);
            _brand = new Brand
            {
                Name = "Car Brand"
            };
            
            await _repository.Create(_brand);
        };

        private Because of = async () => { _disabledBrand = await _repository.Disable(_brand); };

        private It should_mark_a_brand_as_disabled = () => _disabledBrand.Disabled.Should().BeTrue();
    }
}