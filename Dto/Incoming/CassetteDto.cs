using Shared.Models;

namespace Dto.Incoming
{
    public class CassetteDto : ICassette
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
