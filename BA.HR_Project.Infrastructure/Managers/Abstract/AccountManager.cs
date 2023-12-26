using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Abstract
{
    public class AccountManager : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        
        public AccountManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<Response> LogInAsync(LoginUserDto loginUserDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    return Response.Success();
                }
                if (result.IsLockedOut)
                {
                    var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                    var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;
                    return Response.Failure($"Giriş başarısız. Lütfen {timeLeft} dakika sonra tekrar deneyiniz.");
                }
                return Response.Failure("Giriş Başarısız");
            }
            catch
            {
                return Response.Failure("Email ya da parola yanlış girildi.");
            }
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
