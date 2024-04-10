using Shared.Dtos;

namespace Services.Models.TokenServiceModel
{
    public class LoginDtoServiceModel : ILoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
