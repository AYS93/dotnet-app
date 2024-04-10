using Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dto.Incoming
{
    public class TokenRefreshDto : ITokenRefreshDto
    {
        [Required]
        public string? RefreshToken { get; set; }
    }
}
