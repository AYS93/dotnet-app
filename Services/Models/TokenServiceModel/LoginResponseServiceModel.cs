using Shared.Dtos;

namespace Services.Models.TokenServiceModel
{
    public class LoginResponseServiceModel : ILoginResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
