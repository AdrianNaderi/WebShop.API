using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateProduct product)
        {
            if (await _service.GetProductByName(product.Name))
                return BadRequest();
            await _service.CreateProductAsync(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var product = await _service.ReadSingleProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return new OkObjectResult(product);
        }

        [HttpPost("Display")]
        public async Task<IActionResult> GetProducts(DisplayOptions options)
        {
            var products = await _service.ReadAllProductsAsync(options);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost("Filtered")]
        public async Task<IActionResult> GetProducts(Filter filter)
        {
            var result = await _service.GetFilteredProductsAsync(filter);
            IEnumerable<ProductViewModel> products = _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductViewModel>>(result);
            return Ok(products);
        }

        [HttpGet("Filterdata")]
        public async Task<IActionResult> GetFilterData()
        {
            var filterData = _service.GetFilterData();
            return Ok(filterData);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct product)
        {
            await _service.UpdateProductAsync(product);
            return Ok();
        }


    }
}
