namespace Shared.Models
{
    public interface IRfToken
    {
        int Id { get; }
        string RefreshToken { get; }
        bool IsUsed { get; }
        DateTime ExpireDate { get; }
        int UserId { get; }
    }
}
