using Shared.Dtos;

namespace SharedServices
{
    public interface IAuthenticationService
    {
        void Insert(string refreshToken, int id);
        ILoginResponseDto Login(ILoginDto dto);
        ILoginResponseDto Refresh(ITokenRefreshDto dto);
        void Revoke(string token);
    }
}
