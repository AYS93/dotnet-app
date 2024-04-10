using AutoMapper;
using Shared.Models;

namespace Services.Models.UserCassetteServiceModel
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<IUserCassette, UserCassetteServiceModel>();
        }
    }
}
