using AutoMapper;
using Shared.Dtos;
using Shared.Models;

namespace Services.Models.UserServiceModel
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<IUpdateUserDto, UserServiceModel>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<IUser, UserServiceModel>();
            CreateMap<IRegisterUserDto, UserServiceModel>();
        }
    }
}
