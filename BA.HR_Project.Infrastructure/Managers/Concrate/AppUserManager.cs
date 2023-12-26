using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BA.HR_Project.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class AppUserManager : BaseManager<AppUser, IDTO>, IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUserManager(IMapper mapper, IUow uow, UserManager<AppUser> userManager) : base(mapper, uow)
        {
            _userManager = userManager;
        }

        public async Task UpdateAppUser(AppUserDto user)
        {
            var entity = await _userManager.FindByIdAsync(user.Id);

            entity.Adress = user.Adress;
            entity.PhoneNumber = user.PhoneNumber;
            entity.PhotoPath = user.PhotoPath;

            await _userManager.UpdateAsync(entity);
            
        }
    }
}
