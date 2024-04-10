using AutoMapper;
using Dto.Outgoing;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.MappingConfig
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<IUserExtended, UserExtendedDto>()
             .ForMember(dto => dto.FullName, o => o.MapFrom(c => $"{c.FirstName} {c.LastName}"))
             .ForMember(e => e.PermissionIds, s => s.MapFrom(x => x.UserRoles.Select(a => a.Role).SelectMany(h => h.RolePermissions).Select(j => j.PermissionId).ToList()));

            CreateMap<IUserExtended, UserExtendedDto>()
            .ForMember(dto => dto.FullName, o => o.MapFrom(c => $"{c.FirstName} {c.LastName}"));


            CreateMap<ILoginResponseDto, LoginResponseDto>();

            CreateMap<ICassette, CassetteDto>();

        }
    }
}
