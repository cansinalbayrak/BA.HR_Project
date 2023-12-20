using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.Mapping
{
    public class GenaralMapper:Profile
    {
        public GenaralMapper()
        {
            CreateMap<AdressDto, Adress>()
           .ReverseMap();
            CreateMap<AppRoleDto, AppRole>()
           .ReverseMap();
            CreateMap<AppUserDto, AppUser>()
           .ReverseMap();
            CreateMap<CompanyDto, Company>()
           .ReverseMap();
            CreateMap<DepartmentDto, Department>()
            .ReverseMap();
            CreateMap<AppUser, ListSummaryInfoDto>()
                .ReverseMap();
            CreateMap<AppUser, UpdateUserProfile>()
            .ReverseMap();
            CreateMap<LoginUserDto, AppUser>()
                .ReverseMap();
            
        }
    }
}
