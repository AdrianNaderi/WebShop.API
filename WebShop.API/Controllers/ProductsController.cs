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

        [HttpPost("Filtered")]
        public async Task<IActionResult> GetProducts(Filter filter)
        {
            var result = await _service.GetFilteredProducts(filter);
            IEnumerable<ProductViewModel> products = _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductViewModel>>(result);
            return Ok(products);
        }


    }
}
