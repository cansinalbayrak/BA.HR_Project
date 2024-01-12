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
using BA.HR_Project.Infrastructure.Services.Concrate;

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
        private readonly IExpsenseService _expenseService;
        private readonly IDayOffService _dayOffService;
        private readonly IMapper _mapper;

        public AdminEmployeeController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICompanyService companyManager, IDepartmentService departmentManager, IMapper mapper, IAdvanceService advanceService, IExpsenseService expenseService, IDayOffService dayOffService)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _advanceService = advanceService;
            _expenseService = expenseService;
            _dayOffService = dayOffService;
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

            if (newUser.IsSuccess)
            {
                return RedirectToAction("ListEmployee");
            }
            ViewBag.ErrorMessages = newUser.Message;

            return View(vm);
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


            if (data.IsSuccess)
            {
                return RedirectToAction("ListEmployee");
            }
            ViewBag.ErrorMessages = data.Message;

            return View(vm);
        }

        public async Task<IActionResult> DetailsEmployee(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userdto = _mapper.Map<AppUserDto>(user);

                var departmentId = userdto.DepartmentId;
                var companyId = userdto.CompanyId;
                var company = await _companyManager.GetByIdAsync(companyId);
                var department = await _departmentManager.GetByIdAsync(departmentId);

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
            foreach (var item in advancesVm)
            {
                var user = await _userManager.FindByIdAsync(item.AppUserId);
                var userName = user.Name + " " + user.Surname;
                ViewBag.UserName = userName;
            }
            
            ViewBag.AllAdvances = allAdvancesDto;
            ViewBag.ApprovedAdvances = approvedAdvances;
            ViewBag.DeniedAdvances = deniedAdvances;
            return View(advancesVm);
        }

        public async Task<IActionResult> ApprovedAdvance(string id)
        {
            await _advanceService.ApprovedAdvance(id);
            return RedirectToAction("ListAllAdvances");
        }
        public async Task<IActionResult> RejectAdvance(string id)
        {
            await _advanceService.RejectAdvance(id);
            return RedirectToAction("ListAllAdvances");
        }
        public async Task<IActionResult> ListAllExpenses()
        {
            var allExpensesDto = await _expenseService.AllUserExpense();
            var waiting = allExpensesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Waiting).ToList();
            var approved = allExpensesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Approved).ToList();
            var denied = allExpensesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Denied).ToList();

            var expensesVm = _mapper.Map<List<ExpenseViewModel>>(waiting);
            foreach (var item in expensesVm)
            {
                var user = await _userManager.FindByIdAsync(item.AppUserId);
                var userName = user.Name + " " + user.Surname;
                ViewBag.UserName = userName;
            }
            ViewBag.AllExpenses = allExpensesDto;
            ViewBag.ApprovedExpenses = approved;
            ViewBag.DeniedExpenses = denied;
            return View(expensesVm);
        }
        public async Task<IActionResult> ApprovedExpense(string id)
        {
             await _expenseService.ApprovedExpense(id);
            return RedirectToAction("ListAllExpenses");
        }
        public async Task<IActionResult> RejectExpense(string id)
        {
            await _expenseService.RejectExpense(id);
            return RedirectToAction("ListAllExpenses");
        }
        public async Task<IActionResult> ListAllDayOffs()
        {
            var allDayOffsDto = await _dayOffService.AllUserDayOff();
            var waiting = allDayOffsDto.Where(x => x.ConfirmStatus == ConfirmStatus.Waiting).ToList();
            var approved = allDayOffsDto.Where(x => x.ConfirmStatus == ConfirmStatus.Approved).ToList();
            var denied = allDayOffsDto.Where(x => x.ConfirmStatus == ConfirmStatus.Denied).ToList();

            var dayOffsVm = _mapper.Map<List<DayOffViewModel>>(waiting);
            foreach (var item in dayOffsVm)
            {
                var user = await _userManager.FindByIdAsync(item.AppUserId);
                var userName = user.Name + " " + user.Surname;
                ViewBag.UserName = userName;
            }
            ViewBag.AllDayOffs = allDayOffsDto;
            ViewBag.ApprovedDayOffs = approved;
            ViewBag.DeniedDayOffs = denied;
            return View(dayOffsVm);
        }
        public async Task<IActionResult> ApprovedDayOff(string id)
        {
            await _dayOffService.ApprovedDayOff(id);
            return RedirectToAction("ListAllDayOffs");
        }
        public async Task<IActionResult> RejectDayOff(string id)
        {
            await _dayOffService.RejectDayOff(id);
            return RedirectToAction("ListAllDayOffs");
        }
    }
}
