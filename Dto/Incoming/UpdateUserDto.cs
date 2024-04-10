using Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dto.Incoming
{
    public class UpdateUserDto : IUpdateUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
