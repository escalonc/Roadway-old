namespace Roadway.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Brands;
    using Core.Brands.Dto;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<IEnumerable<GetBrand>> Get(int page = 1, int size = 10)
        {
            return await _brandService.FindAll(page, size);
        }

        [HttpGet("search")]
        public async Task<JsonResult> Search(string searchTerm, int page = 1, int size = 10)
        {
            var data = await _brandService.Search(searchTerm, page, size);
            return new JsonResult(data);

        }

        // GET: api/Brands/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brands
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
