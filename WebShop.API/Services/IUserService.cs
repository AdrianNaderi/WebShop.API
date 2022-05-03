using Microsoft.AspNetCore.Identity;
using WebShop.API.Models.Entities;

namespace WebShop.API.Services
{
        public interface IUserService
        {
                Task<IdentityUser> FindUserByEmailAsync(string email);
        }
}
