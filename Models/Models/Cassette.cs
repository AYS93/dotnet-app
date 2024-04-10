using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Cassette : ICassette
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<UserCassette> UserCassettes { get; set; }
    }
}
