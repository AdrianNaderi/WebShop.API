using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
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
    }
}
