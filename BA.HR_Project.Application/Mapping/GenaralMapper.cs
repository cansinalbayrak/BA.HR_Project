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
    public class GenaralMapper : Profile
    {
        public GenaralMapper()
        {
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
            CreateMap<ListDetailInfoDto, AppUser>()
           .ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>()
           .ReverseMap();
            CreateMap<Expense, ExpenseDto>()
                .ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeDto>()
                .ReverseMap();

            CreateMap<AppUser, AppUserUpdateForEmployeeDto>().ReverseMap();

            CreateMap<AppUser, AppUserUpdateForAdminDto>().ReverseMap();

            CreateMap<AppUser, AppUser>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, AppUserUpdatePasswordDto>()
                .ReverseMap();

            





            CreateMap<DayOff, DayOffDto>() .ReverseMap();
            CreateMap<AdvanceDto,Advance>()
            .ReverseMap();
            CreateMap<ExpenseDto,Expense>() 
                .ReverseMap();
            CreateMap<ListManagerDto,AppUser>() 
                .ReverseMap();
            CreateMap<UpdateManagerDto, AppUser>()
                .ReverseMap();

           
        }
    }
}
