using WebShop.API.Models.ViewModels.User;

namespace WebShop.API.Services
{
        public interface ILoginService
        {
                Task<string> LoginWithEmailAsync(LoginUser loginUser);
                Task<string> LoginWithUsernameAsync(LoginUser loginUser);
        }
}
