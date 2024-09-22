using System;
using AutoMapper;
using Identity.DAL.Users;
using Identity.DAL.Users.Models;

namespace Identity.Helpers.Mappers;

public class IdentityMapper : Profile
{
    public IdentityMapper()
    {
        CreateMap<User, SingInUserDto>()
        .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(x => x.RoleName).ToArray<string>()));
        CreateMap<User, RefreshTokenUserDto>()
        .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(x => x.RoleName).ToArray<string>()))
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
    }
}
