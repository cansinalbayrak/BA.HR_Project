using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _signInManager = signInManager; 
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

                var user = await _userManager.FindByEmailAsync(dto.Email);
                var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");
                }
                
                return View(vm);
            }
            return View(vm);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
