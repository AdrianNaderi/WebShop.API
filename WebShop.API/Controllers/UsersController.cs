using Microsoft.AspNetCore.Mvc;
using WebShop.API.Models.ViewModels.User;
using WebShop.API.Services;

namespace WebShop.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
                private readonly ILoginService _loginService;

                public UsersController(ILoginService loginService)
                {
                        _loginService = loginService;
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
        }
}
