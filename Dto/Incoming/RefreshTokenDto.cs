using Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dto.Incoming
{
    public class RefreshTokenDto : IRefreshTokenIncomingDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
