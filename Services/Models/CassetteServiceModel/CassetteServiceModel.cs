using Shared.Models;

namespace Services.Models.CassetteServiceModel
{
    public class CassetteServiceModel : ICassette
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
