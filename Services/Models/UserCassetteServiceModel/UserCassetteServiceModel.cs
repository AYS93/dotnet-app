using Shared.Models;

namespace Services.Models.UserCassetteServiceModel
{
    public class UserCassetteServiceModel : IUserCassette
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CassetteId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
