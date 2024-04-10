using Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class RfToken : IRfToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public bool IsUsed { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
