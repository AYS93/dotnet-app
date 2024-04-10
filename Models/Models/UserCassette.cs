using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class UserCassette : IUserCassette
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CassetteId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public User User { get; set; }
        public Cassette Cassette { get; set; }
    }
}
