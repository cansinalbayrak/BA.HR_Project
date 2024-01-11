using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrasturucture.Services.Concrate
{
    public interface IAppUserService : IService<AppUser,IDTO>
    {
        public Task<Response> AddAppUser(AppUserDto userDto, ClaimsPrincipal User);
        public Task<Response<AppUser>> UpdateAppUser(AppUser userNewProps);
         Task<Response> AddManager(AppUserDto managerDto);
        public Task<Response<AppUser>> UpdateForManager(AppUser userNewProps);




    }
}
