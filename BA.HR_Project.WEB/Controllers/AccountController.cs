using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using BA.HR_Project.WEB.ModelValidators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        
        public AccountController(IAccountService accountService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _accountService = accountService;
            _userManager = userManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginUserViewModel vm)
        {
            var validator = new LoginViewModelValidator();
            var validationResult = await validator.ValidateAsync(vm);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(vm);
            }

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<LoginUserDto>(vm);
                var result = await _accountService.LogInAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("AfterLogin", "Account");
                }
                ModelState.AddModelError(string.Empty, "Invalid email or password");

                return View(vm);
            }

            return View(vm);
        }
        [Authorize]
        public async Task<IActionResult> AfterLogin()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                IList<string> userRoles = await _userManager.GetRolesAsync(user);

                if (userRoles.Contains("Manager"))
                {
                    return RedirectToAction("ListManager", "Manager", new { area = "Manager" });
                }
                else if (userRoles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> UpdatePassword(string token, string newUserId) 
        {
            var user = await _userManager.FindByIdAsync(newUserId);
            var UserDto = _mapper.Map<AppUserUpdatePasswordDto>(user);
            var UserVM = _mapper.Map<AppUserUpdatePasswordViewModel>(UserDto);


            return View(UserVM);

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(AppUserUpdatePasswordViewModel uppasvm)
        {

            var validator = new AppUserUpdatePasswordViewModelValidator();
            var validationResult = await validator.ValidateAsync(uppasvm);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(uppasvm);
            }

            var user = await _userManager.FindByIdAsync(uppasvm.Id);
            var control = await _userManager.CheckPasswordAsync(user, uppasvm.OldPassword);
            if (control)
            {
                var updatePassword = await _userManager.ChangePasswordAsync(user, uppasvm.OldPassword, uppasvm.NewPassword);

                if (updatePassword.Succeeded)
                {
                    await _accountService.SignOutAsync();
                    return RedirectToAction("Index", "Home");

                }
                return View(uppasvm);
            }

            return View(uppasvm);

        }
    }
}
