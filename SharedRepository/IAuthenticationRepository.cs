using Shared.Models;

namespace SharedRepository
{
    public interface IAuthenticationRepository
    {
        void InsertToken(IRfToken data);
        IRfToken GetToken(int id, string rToken);
        DateTime GetExpireTime(int id);
        void SetIsUsed(int id, string rToken);
        void SetIsUsedForAll(int id);
    }
}
