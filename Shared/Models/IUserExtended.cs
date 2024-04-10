namespace Shared.Models
{
    public interface IUserExtended : IUser
    {
        List<IUserRole> UserRoles { get; }
    }
}
