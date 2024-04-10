using Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dto.Incoming
{
    public class RegisterUserDto : IRegisterUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
