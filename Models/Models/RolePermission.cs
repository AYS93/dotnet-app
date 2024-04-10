using Shared.Models;

namespace Models.Models
{
    public class RolePermission : IRolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
        IRole IRolePermission.Role => throw new NotImplementedException();
        Shared.Enums.Permission IRolePermission.Permission => throw new NotImplementedException();
    }
}
