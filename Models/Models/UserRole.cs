using Shared.Models;

namespace Models.Models
{
    public class UserRole : IUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

        IUser IUserRole.User => User;

        IRole IUserRole.Role => Role;
    }
}
