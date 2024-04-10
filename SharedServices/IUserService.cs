using Shared.Dtos;
using Shared.Models;

namespace SharedServices
{
    public interface IUserService
    {
        IUser GetUserById(int id);
        IUserExtended GetCurrentUser();
        List<IUser> GetAllUsers();
        void Register(IRegisterUserDto dto);
        void UpdateUser(int id, IUpdateUserDto dto);
        int GetUserId(ILoginDto dto);
    }
}
