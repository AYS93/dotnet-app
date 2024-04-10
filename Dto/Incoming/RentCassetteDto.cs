using Shared.Dtos;

namespace Dto.Incoming
{
    public class RentCassetteDto : IRentCassetteDto
    {
        public int CasseteId { get; set; }
        public int UserId { get; set; }
    }
}
