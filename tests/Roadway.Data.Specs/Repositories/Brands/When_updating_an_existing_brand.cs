using System.Linq;
using FluentAssertions;
using Machine.Specifications;
using Roadway.Data.Contexts;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;
using Roadway.Data.Specs.Contexts;

namespace Roadway.Data.Specs.Repositories.Brands
{
    class When_updating_an_existing_brand
    {
        private static RoadwayContext _databaseContext;
        private static BaseRepository<Brand> _repository;
        private static Brand _oldBrand;
        private static bool _wasUpdated;

        private Establish context = async () =>
        {
            _wasUpdated = false;
            _databaseContext = new InMemoryDatabaseContextFactory().Create();
            _repository = new BrandRepository(_databaseContext);
            _oldBrand = await _repository.Create(new Brand
            {
                Name = "Kia"
            });

        };

        private Because of = async () =>
        {
            _oldBrand.Name = "Honda";
            await _repository.Update(_oldBrand);
            _wasUpdated = _repository.Filter(brand => brand.Name == "Honda").Any();
        };

        It should_change_the_name_of_the_brand = () => _wasUpdated.Should().BeTrue();
    }
}