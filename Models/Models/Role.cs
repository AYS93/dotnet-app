using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Role : IRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }

        List<IUserRole> IRole.UserRoles => throw new NotImplementedException();

        List<IRolePermission> IRole.RolePermissions => RolePermissions.ToList<IRolePermission>();

    }
}
