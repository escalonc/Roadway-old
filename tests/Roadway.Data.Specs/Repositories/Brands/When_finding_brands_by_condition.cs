using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Machine.Specifications;
using Roadway.Data.Contexts;
using Roadway.Data.Entities;
using Roadway.Data.Repositories;
using Roadway.Data.Specs.Contexts;

namespace Roadway.Data.Specs.Repositories.Brands
{
    class When_finding_brands_by_condition
    {
        private static IEnumerable<Brand> _brands;
        private static IEnumerable<Brand> _selectedBrands;
        private static RoadwayContext _databaseContext;
        private static BaseRepository<Brand> _repository;
        
        private Establish context = async () =>
        {
            _databaseContext = new InMemoryDatabaseContextFactory().Create();
            _repository = new BrandRepository(_databaseContext);
            
            _selectedBrands = new List<Brand>
            {
                new Brand
                {
                    Name = "Kia"
                },
                new Brand
                {
                    Name = "Fiat"
                }
            };
            
            await _repository.Create(_selectedBrands.ElementAt(0));
            await _repository.Create(_selectedBrands.ElementAt(1));
        };

        private Because of = () =>
        {
            _brands = _repository.Filter(brand => brand.Name == "Fiat" || brand.Name == "Kia");
        };

        private It should_return_the_matching_projects = () => _brands.Should().BeEquivalentTo(_selectedBrands);

    }
}