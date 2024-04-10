using AutoMapper;
using Models.Models;
using Shared.Models;

namespace Repository.Models
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<IUser, User>();
            CreateMap<IRole, Role>();
            CreateMap<IUserCassette, UserCassette>();
            CreateMap<ICassette, Cassette>();
            CreateMap<IRfToken, RfToken>();
        }
    }
}
