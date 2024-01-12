using AutoMapper;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.HelperMethods;
using BA.HR_Project.WEB.ModelValidators;
using BA.HR_Project.WEB.Areas.Manager.Models;
using Microsoft.AspNetCore.Authorization;

namespace BA.HR_Project.WEB.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee,Admin")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IMapper _mapper;

        public EmployeeController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICompanyService companyManager, IDepartmentService departmentManager, IMapper mapper)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {


            var userId = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);
            var userdto = _mapper.Map<AppUserDto>(user);

            var departmentId = userdto.DepartmentId;
            var companyId = userdto.CompanyId;


            var company = await _companyManager.GetByIdAsync(companyId);
            var department = await _departmentManager.GetByIdAsync(departmentId);

            var userViewModels = _mapper.Map<ListSummarInfoViewModel>(userdto);
            ViewBag.DepartmentName = department.Context.Name;
            ViewBag.CompanyName = company.Context.Name;

            return View(userViewModels);
        }

        public async Task<IActionResult> Detail()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);
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
        public async Task<IActionResult> Update()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var userDto = _mapper.Map<AppUserUpdateForEmployeeDto>(user);
                var userVM = _mapper.Map<AppUserUpdateForEmployeeVM>(userDto);

                return View(userVM);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateForEmployeeVM vm)
        {
            var validator = new AppUserUpdateForEmployeeVMValidator();
            var validationResult = await validator.ValidateAsync(vm);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                var us = await _userManager.GetUserAsync(User);
                vm.PhotoPath = us.PhotoPath;
                return View(vm);
            }

            var photoPath = await ImageHelper.SaveImageFile(vm.Photo);
            vm.PhotoPath = photoPath;

            var userNewPropsDto = _mapper.Map<AppUserUpdateForEmployeeDto>(vm);
            var userNewProps = _mapper.Map<AppUser>(userNewPropsDto);

            var newUser = await _appUserManager.UpdateAppUser(userNewProps);

            if (newUser != null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> MyManager()
        {
            var GetEmployee = await _userManager.GetUserAsync(User);
            List<AppUser> RelatedManagers = new List<AppUser>();

            if (GetEmployee != null)
            {
                var AllManagers = await _userManager.GetUsersInRoleAsync("Admin");

                foreach (var manager in AllManagers)
                {
                    if (manager.CompanyId == GetEmployee.CompanyId)
                    {
                        RelatedManagers.Add(manager);
                    }
                }

                if (RelatedManagers != null)
                {
                    var managerDtos = _mapper.Map<List<ListManagerDto>>(RelatedManagers);
                    var listManagerVm = _mapper.Map<List<ListManagerViewModel>>(managerDtos);

                    for (int i = 0; i < RelatedManagers.Count; i++)
                    {
                        var GetrelatedCompanyName = await _companyManager.GetByIdAsync(RelatedManagers[i].CompanyId);
                        if (GetrelatedCompanyName.IsSuccess)
                        {
                            listManagerVm[i].CompanyName = GetrelatedCompanyName.Context.Name;
                        }
                    }
                    return View(listManagerVm);
                }
                return View();
            }
            return View();


        }


    }
}
