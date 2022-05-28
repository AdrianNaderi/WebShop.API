using WebShop.API.Models.ViewModels.User;

namespace WebShop.API.Services
{
    public interface ILoginService
    {
        Task<LoginUserResponse> LoginWithEmailAsync(LoginUser loginUser);
        Task<LoginUserResponse> LoginWithUsernameAsync(LoginUser loginUser);
    }
}
