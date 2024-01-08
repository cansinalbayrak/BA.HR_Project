using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Areas.Admin.Models;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NuGet.Packaging.Signing;
using BA.HR_Project.WEB.HelperMethods;
using BA.HR_Project.Domain.Enums;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]

    public class AdminEmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IAppUserService _appUserManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IAdvanceService _advanceService;
        private readonly IMapper _mapper;

        public AdminEmployeeController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICompanyService companyManager, IDepartmentService departmentManager, IMapper mapper, IAdvanceService advanceService)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _advanceService = advanceService;
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
            var users = await _userManager.Users.Include(x => x.Company).Include(x => x.Department).ToListAsync();
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
            if (vm.PhotoPath ==null)
            {
                vm.PhotoPath = "/mexant/assets/images/Default.jpg";
            }

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

            var userDto = _mapper.Map<AppUserDto>(vm);
            var newUser = await _appUserManager.AddAppUser(userDto, User);

            if (newUser != null)
            {
                return RedirectToAction("ListEmployee");
            }
            return RedirectToAction("Warning", "Home");
        }

        public async Task<IActionResult> UpdateEmployee(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var userdto = _mapper.Map<AppUserUpdateForAdminDto>(user);
                var userViewModel = _mapper.Map<AppUserUpdateForAdminVM>(userdto);

                ViewBag.Citizien = user.IsTurkishCitizen;

                return View(userViewModel);
            }
            return RedirectToAction("ListEmployee");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(AppUserUpdateForAdminVM vm)
        {

            var validator = new AppUserUpdateForAdminVMValidator();
            var validationResult = await validator.ValidateAsync(vm);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(vm);
            }

            

            var updateUserDto = _mapper.Map<AppUserUpdateForAdminDto>(vm);
            var userNewProps = _mapper.Map<AppUser>(updateUserDto);

            var data = await _appUserManager.UpdateAppUser(userNewProps);


            if (data != null)
            {
                return RedirectToAction("ListEmployee");
            }

            return View();
        }

        public async Task<IActionResult> DetailsEmployee(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userdto = _mapper.Map<AppUserDto>(user);

                var departmentId = userdto.DepartmentId;
                var companyId = userdto.CompanyId;
                var company = await _companyManager.Get(true, x => x.Id == companyId);
                var department = await _departmentManager.Get(true, x => x.Id == departmentId);

                var userViewModels = _mapper.Map<ListDetailInfoViewModel>(userdto);
                ViewBag.DepartmentName = department.Context.Name;
                ViewBag.CompanyName = company.Context.Name;

                return View(userViewModels);
            }
            return RedirectToAction("ListEmployee");

        }
        public async Task<IActionResult> ListAllAdvances()
        {
            var allAdvancesDto = await _advanceService.AllUserAdvance();
            var waitingAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Waiting).ToList();
            var approvedAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Approved).ToList();
            var deniedAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Denied).ToList();

            var advancesVm = _mapper.Map<List<AdvanceViewModel>>(waitingAdvances);
            ViewBag.AllAdvances = allAdvancesDto;
            ViewBag.ApprovedAdvances = approvedAdvances;
            ViewBag.DeniedAdvances = deniedAdvances;
            return View(advancesVm);
        }
        public async Task<IActionResult> ApprovedAdvance(string id)
        {
            await _advanceService.ApprovedAdvance(id);
            return View();
        }
    }
}
