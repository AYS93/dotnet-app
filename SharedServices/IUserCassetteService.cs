using Shared.Dtos;
using Shared.Models;

namespace SharedServices
{
    public interface IUserCassetteService
    {
        void RentCassette(IRentCassetteDto data);
        void ReturnCassette(IRentCassetteDto data);
        List<ICassette> GetUserCassettes();
        List<ICassette> GetRentedCassetByUserId(int id);
    }
}
