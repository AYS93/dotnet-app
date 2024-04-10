using Shared.Models;

namespace SharedRepository
{
    public interface IUserRepository : IRepository<IUser>
    {
        IUserExtended GetByIdIUserExtended(int id);
        List<IUser> GetAll();
        IUser GetUser(string firstName, string password);
        List<int> GetUserPermissions(int id);
        bool IsEmailUnique(string email);
        int GetUserIdByEmailAndPassword(string firstName, string password);
        IUser GetByIdIUser(int id);
    }
}
