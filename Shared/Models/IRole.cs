namespace Shared.Models
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IUserRole> UserRoles { get; }
        List<IRolePermission> RolePermissions { get; }
    }
}
