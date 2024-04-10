namespace Shared.Dtos
{
    public interface ILoginResponseDto
    {
        string Token { get; }
        string RefreshToken { get; }
    }
}
