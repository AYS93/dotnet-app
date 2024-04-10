using AutoMapper;
using Shared.Models;

namespace Services.Models.CassetteServiceModel
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ICassette, CassetteServiceModel>();
        }
    }
}
