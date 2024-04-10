namespace Shared.Models
{
    public interface IUserCassette
    {
        int Id { get; }
        int UserId { get; }
        int CassetteId { get; }
        DateTime TakeDate { get; }
        DateTime? ReturnDate { get; }
    }
}
