using Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dto.Incoming
{
    public class LoginDto : ILoginDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
