using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.ViewModels.UserModels
{
    public class UserRegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
