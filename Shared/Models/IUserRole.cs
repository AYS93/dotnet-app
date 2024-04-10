namespace Shared.Models
{
    public interface IUserRole
    {
        int UserId { get; }
        int RoleId { get; }
        IUser User { get; }
        IRole Role { get; }
    }
}
