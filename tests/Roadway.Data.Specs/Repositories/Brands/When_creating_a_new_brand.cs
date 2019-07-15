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
}