using Shared.Models;

namespace SharedRepository
{
    public interface IUserCassetteRepository
    {
        int NumberOfTaken(int idUser);
        void Insert(IUserCassette data);
        IUserCassette FindNotReturned(int idUser, int idCassette);
        void Update(int id, IUserCassette data);
        List<ICassette> GetUserCassettes(int id);
    }
}
