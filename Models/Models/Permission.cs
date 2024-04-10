using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }

    }
}
