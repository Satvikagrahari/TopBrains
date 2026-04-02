using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;
using UserService.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserService.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser, UserProfileDto>().ReverseMap();
        CreateMap<UpdateProfileDto, ApplicationUser>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.Ignore());
    }
}
