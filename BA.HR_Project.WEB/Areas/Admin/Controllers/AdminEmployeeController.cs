using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class AdminEmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IMapper _mapper;
        public AdminEmployeeController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICompanyService companyManager, IDepartmentService departmentManager, IMapper mapper)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _mapper = mapper;
        }
        [HttpGet("/Admin/Employee/Index")]
        public IActionResult Index()
        {
            return View();
        }

  
        [HttpGet()]
        public async Task<IActionResult> ListEmployee()
        {
            var users = await _userManager.Users.Include(x=>x.Company).Include(x=>x.Department).ToListAsync();
            var usersDto = _mapper.Map<List<AppUserDto>>(users);
            var usersvm = _mapper.Map<List<ListEmployeeViewModel>>(usersDto);

            return View(usersvm);
        }

        public async Task<IActionResult> AddEmployee()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AppUserViewModel vm)
        {
            var newAppuser = _mapper.Map<AppUserDto>(vm);
            newAppuser.Id = Guid.NewGuid().ToString();

            var InsertAction = await _appUserManager.Insert(newAppuser);
            if (InsertAction.IsSuccess)
            {
                return RedirectToAction("ListEmployee");
            }
            return RedirectToAction("Warning","Home");
        }


        public async Task<IActionResult> UpdateEmployee()
        {
            var userId = _userManager.GetUserId(User);
            var updateUserAction = await _appUserManager.Get(true, u => u.Id == userId);
            var user = updateUserAction.Context;

            var userViewModel = _mapper.Map<AppUserViewModel>(user);

            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(AppUserViewModel vm)
        {
            var validator = new AppUserViewModelValidator();
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
              var updateUser = _mapper.Map<AppUserDto>(vm);
                await _appUserManager.UpdateV2(updateUser);
                return RedirectToAction("Index");
            }
            return View();
        }




        public async Task<IActionResult> DetailsEmployee()
        {
            return View();


        }


    }
}
