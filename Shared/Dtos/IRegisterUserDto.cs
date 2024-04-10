namespace Shared.Dtos
{
    public interface IRegisterUserDto
    {
        string FirstName { get; }
        string LastName { get; }
        string Password { get; }
        string Email { get; }
    }
}
