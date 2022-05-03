using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.API.Data;
using WebShop.API.Models.Entities;

namespace WebShop.API.Services
{
        public class UserService : IUserService
        {

                private readonly AppDbContext _db;

                public UserService(AppDbContext db)
                {
                        _db = db;
                }


                public async Task<IdentityUser> FindUserByEmailAsync(string email)
                {
                        return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
                }
        }
}

