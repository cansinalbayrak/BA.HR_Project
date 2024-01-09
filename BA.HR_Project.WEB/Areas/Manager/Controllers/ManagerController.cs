using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Areas.Manager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BA.HR_Project.WEB.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        private readonly UserManager<AppUser> _userManager;

        public ManagerController(IAppUserService userService, IMapper mapper, IDepartmentService departmentService, ICompanyService companyService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _mapper = mapper;
            _departmentService = departmentService;
            _companyService = companyService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddManager() 
        {
            List<CompanyCustom> allCompanies = _companyService.GetAllCompanyCustomColumn();
            List<string> companyNames = new List<string>();
            for (int i = 0; i < allCompanies.Count; i++)
            {
                companyNames.Add(allCompanies[i].CompanyName + "/" + allCompanies[i].Id);
            }
            ViewBag.CompanyNames = companyNames;

            List<DepartmentCustom> allDepartments = _departmentService.GetAllDepartmentCustomColumn();
            List<string> departmentName = new List<string>();
            for (int i = 0; i < allDepartments.Count; i++)
            {
                departmentName.Add(allDepartments[i].DepartmentName + "/" + allDepartments[i].Id);
            }
            ViewBag.DepartmentName = departmentName;
          


            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddManager(AddManagerViewModel model) 
        {
            if (model.PhotoPath == null)
            {
                model.PhotoPath = "/mexant/assets/images/Default.jpg";
            }
            var departmentId = model.DepartmentId.Split("/")[1];
            model.DepartmentId = departmentId;
            var companyId = model.CompanyId.Split("/")[1];
            model.CompanyId = companyId;

            var managerDto = _mapper.Map<AppUserDto>(model);
            var newManager = await _userService.AddManager(managerDto);
            if (newManager != null) 
            {
                await _userManager.AddToRoleAsync(newManager, "Admin");
                return RedirectToAction("ListManager");
            
            }
            return RedirectToAction("Warning", "Home");


           
        }
        public async Task<IActionResult> ListManager() 
        {
            var managers = await _userManager.GetUsersInRoleAsync("Admin");

            var listManagerDto = new List<ListManagerDto>();

            foreach (var manager in managers)
            {
                var company = await _companyService.GetByIdAsync(manager.CompanyId);

                var managerDto = new ListManagerDto
                {
                    
                    Name = manager.Name+" "+manager.SecondName,
                    SurName = manager.Surname+" "+manager.SecondSurname,
                    CompanyName = company.Context.Name,
                    PhotoPath = manager.PhotoPath,
                    PhoneNumber = manager.PhoneNumber,
                    Email = manager.Email,
                                                        
                };

                listManagerDto.Add(managerDto);
            }

            var listManagerVm = _mapper.Map<List<ListManagerViewModel>>(listManagerDto);
            return View(listManagerVm);
        }
    }
}
