using Shared.Models;

namespace Services.Models.UserServiceModel
{
    public class UserServiceModel : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }

        public List<IUserRole> UserRole => throw new NotImplementedException();
    }
}
