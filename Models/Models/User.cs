using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class User : IUserExtended
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<UserCassette> UserCassettes { get; set; }
        public List<RfToken> RfTokens { get; set; }
        List<IUserRole> IUserExtended.UserRoles => UserRoles.ToList<IUserRole>();
    }
}

