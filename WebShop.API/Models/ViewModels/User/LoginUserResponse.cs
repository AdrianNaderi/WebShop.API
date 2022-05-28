namespace WebShop.API.Models.ViewModels.User
{
    public class LoginUserResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public LoginUserResponse()
        {

        }

        public LoginUserResponse(string email, string name, string token)
        {
            Email = email;
            Name = name;
            Token = token;
        }
    }
}
