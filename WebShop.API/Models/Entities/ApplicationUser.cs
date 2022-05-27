using Microsoft.AspNetCore.Identity;
using WebShop.API.Models.ViewModels.UserModels;

namespace WebShop.API.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(UserRegisterModel model)
        {
            UserName = model.UserName;
            Email = model.Email;
        }
    }
}
