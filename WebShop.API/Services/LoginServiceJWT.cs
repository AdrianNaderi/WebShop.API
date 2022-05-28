using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebShop.API.Models.ViewModels.User;

namespace WebShop.API.Services
{
    public class LoginServiceJWT : ILoginService
    {
        private readonly AppSettings _appSettings;
        SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;

        public LoginServiceJWT(IOptions<AppSettings> appSettings, SignInManager<IdentityUser> signInManager, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<LoginUserResponse> LoginWithEmailAsync(LoginUser loginUser)
        {
            var user = await _userService.FindUserByEmailAsync(loginUser.Payload);
            if (user is null)
                return null;

            var login = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, lockoutOnFailure: false);
            if(!login.Succeeded)    
                return null;

            var token = HandingOverToken(user.UserName);
            return new LoginUserResponse(user.Email, user.UserName, token);

        }

        public async Task<LoginUserResponse> LoginWithUsernameAsync(LoginUser loginUser)
        {
            var user = await _userService.FindUserByUserNameAsync(loginUser.Payload);
            var login = await _signInManager.PasswordSignInAsync(loginUser.Payload, loginUser.Password, false, lockoutOnFailure: false);
            if (!login.Succeeded)
                return null;

            var token = HandingOverToken(user.UserName);
            return new LoginUserResponse(user.Email, user.UserName, token);


        }

        private string HandingOverToken(string username)
        {
            var descriptor = CreateTokenDescriptor(username);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(string username)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            return new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
        }
    }
}
