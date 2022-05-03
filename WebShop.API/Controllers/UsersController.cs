using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.ViewModels.UserModels;
using WebShop.API.Models.ViewModels.User;
using WebShop.API.Services;
using System.Threading.Tasks;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(ILoginService loginService, UserManager<IdentityUser> userManager)
        {
            _loginService = loginService;
            _userManager = userManager;
        }
        

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser)
        {
            if (string.IsNullOrEmpty(loginUser.Payload))
                return BadRequest("Payload cannot be empty");

            var isEmail = loginUser.Payload.Contains('@');
            var result = string.Empty;

            if (isEmail)
                result = await _loginService.LoginWithEmailAsync(loginUser);
            else
                result = await _loginService.LoginWithUsernameAsync(loginUser);

            if (result is null)
                return BadRequest("Login Failed");

            return Ok(result);
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
