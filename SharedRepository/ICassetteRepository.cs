using Shared.Models;

namespace SharedRepository
{
    public interface ICassetteRepository
    {
        int CountCassette(int idCassette);
        void Update(int id, ICassette data);
        ICassette GetCassette(int idCassette);
        List<ICassette> GetAll();
        void Insert(ICassette type);
        int? getMaxId();
    }
}
