using Shared.Models;

namespace Services.Models.TokenServiceModel
{
    public class TokenServiceModel : IRfToken
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UserId { get; set; }
    }
}
