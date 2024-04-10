using Shared.Enums;

namespace Shared.Models
{
    public interface IRolePermission
    {
        int RoleId { get; }
        int PermissionId { get; }
        IRole Role { get; }
        Permission Permission { get; }
    }
}
