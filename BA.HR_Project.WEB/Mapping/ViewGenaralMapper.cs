using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.WEB.Areas.Admin.Models;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Components;

namespace BA.HR_Project.WEB.Mapping
{
    public class ViewGenaralMapper:Profile
    {
        public ViewGenaralMapper()
        {
            CreateMap<AppRoleDto, AppRoleViewModel>()
           .ReverseMap();
            CreateMap<AppUserDto, AppUserViewModel>()
           .ReverseMap();
            CreateMap<CompanyDto, CompanyViewModel>()
           .ReverseMap();
            CreateMap<DepartmentDto, DepartmentViewModel>()
           .ReverseMap();
            CreateMap<AppUserDto, ListSummarInfoViewModel>()
           .ReverseMap();
            CreateMap<AppUserDto, UpdateUserProfileViewModel>()
           .ReverseMap();
            CreateMap<LoginUserViewModel, LoginUserDto>()
           .ReverseMap();
            CreateMap<AppUserDto, ListDetailInfoViewModel>()
         .ReverseMap();
            CreateMap<AppUserDto, ListEmployeeViewModel>()
         .ReverseMap();
            CreateMap<AppUserUpdateDto, AppUserUpdateViewModel>()
         .ReverseMap();
        }
    }
}
