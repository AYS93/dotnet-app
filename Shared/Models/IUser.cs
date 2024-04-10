namespace Shared.Models
{
    public interface IUser
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Password { get; }

    }
}
