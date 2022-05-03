using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.ViewModels.UserModels;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model) 
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var registration = await _userManager.CreateAsync(user);
                if (registration.Succeeded)
                {
                    return new OkObjectResult(user);
                }
            }

            return new BadRequestResult();
        }
    }
}
