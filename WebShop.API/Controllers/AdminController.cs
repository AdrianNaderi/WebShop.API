using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost("Brand")]
        public async Task<IActionResult> CreateBrand (CreateBrand brand)
        {
            await _service.CreateBrandAsync(brand);
            return Ok();
        }

        [HttpPost("Category")]
        public async Task<IActionResult> CreateCategory (CreateCategory category)
        {
            await _service.CreateCategoryAsync(category);
            return Ok();
        }

        [HttpPost("Color")]
        public async Task<IActionResult> CreateColor (CreateColor color)
        {
            await _service.CreateColorAsync(color);
            return Ok();
        }

        [HttpPost("Size")]
        public async Task<IActionResult> CreateSize (CreateSize size)
        {
            await _service.CreateSizeAsync(size);
            return Ok();
        }


        [HttpPost("UpdateColor")]
        public async Task<IActionResult> UpdateColor (string color, string hex)
        {
            await _service.UpdateColorAsync(color, hex);
            return Ok();
        }

        [HttpPost("LinkColor")]
        public async Task<IActionResult> AttachColor (CreateProductColor productColor)
        {
            await _service.CreateProductColorAsync(productColor);
            return Ok();
        }

    }
}
