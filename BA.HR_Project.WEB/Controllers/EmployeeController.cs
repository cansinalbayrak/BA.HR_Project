using AutoMapper;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IAdressService _adressManager;
        private readonly IMapper _mapper;

        public EmployeeController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICompanyService companyManager, IDepartmentService departmentManager, IAdressService adressManager, IMapper mapper)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _adressManager = adressManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var GetuserdtoAction = await _appUserManager.Get(true, x => x.Id == userId);
            var userdto = GetuserdtoAction.Context;

            var departmentId = userdto.DepartmentId;
            var companyId = userdto.CompanyId;
            var company = await _companyManager.Get(true, x => x.Id == companyId);
            var department = await _departmentManager.Get(true, x => x.Id == departmentId);
            var adress = await _adressManager.Get(true, x => x.Id == userdto.AdressId);

            var userViewModels = _mapper.Map<ListSummarInfoViewModel>(userdto);
            ViewBag.DepartmentName = department.Context.Name;
            ViewBag.CompanyName = company.Context.Name;

            string AllAdress = adress.Context.City + " " + adress.Context.District + " " + adress.Context.ZipCode;

            ViewBag.AllAdress = AllAdress;
            return View(userViewModels);
        }

        public async Task<IActionResult> Detail()
        {
            var userId = _userManager.GetUserId(User);
            var GetuserdtoAction = await _appUserManager.Get(true, x => x.Id == userId);
            var userdto = GetuserdtoAction.Context;
           
            var departmentId = userdto.DepartmentId;
            var companyId = userdto.CompanyId;
            var company = await _companyManager.Get(true, x => x.Id == companyId);
            var department = await _departmentManager.Get(true, x => x.Id == departmentId);
            var adress = await _adressManager.Get(true, x => x.Id == userdto.AdressId);

            var userViewModels = _mapper.Map<ListDetailInfoViewModel>(userdto);
            ViewBag.DepartmentName = department.Context.Name;
            ViewBag.CompanyName = company.Context.Name;

            string AllAdress = adress.Context.City + " " + adress.Context.District + " " + adress.Context.ZipCode;

            ViewBag.AllAdress = AllAdress;
            return View(userViewModels);

        }
        public async Task<IActionResult> Update()
        {
            var userId = _userManager.GetUserId(User);
            var userdto = await _appUserManager.Get(true, x => x.Id == userId);
            var userViewModels = _mapper.Map<UpdateUserProfileViewModel>(userdto.Context);
            return View(userViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserProfileViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var updateUserDto = _mapper.Map<AppUserDto>(vm);
                
                await _appUserManager.Update(updateUserDto);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
