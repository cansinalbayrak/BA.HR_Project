using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Authorization;
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
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<LoginUserDto>(vm);
                var result = await _accountService.LogInAsync(dto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("AfterLogin", "Account");
                }

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

                if (userRoles.Contains("Admin"))
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
    }
}
