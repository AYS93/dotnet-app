using Shared.Models;

namespace SharedServices
{
    public interface ICassetteService
    {
        List<ICassette> GetAllCassettes();
        void Insert(ICassette cassette);
        void Update(int id, ICassette cassette);
    }
}
