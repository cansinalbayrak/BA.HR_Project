using AutoMapper;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class AdminHomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IMapper _mapper;

        public AdminHomeController(UserManager<AppUser> userManager, IMapper mapper, IDepartmentService departmentManager, ICompanyService companyManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _departmentManager = departmentManager;
            _companyManager = companyManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var GetUserAction = await _userManager.GetUserAsync(User);
            var companyId = GetUserAction.CompanyId;
            var companyAction = await _companyManager.GetByIdAsync(companyId);
            var company = companyAction.Context;
            var GetAllUserAction = await _userManager.Users.ToListAsync();
            var departmentsAction = await _departmentManager.GetAll();
            var departmentsdto = departmentsAction.Context;

            if (GetUserAction !=null) 
            {
                var Welcome = GetUserAction.Name + " " + GetUserAction.Surname;
                var users = GetAllUserAction.Count;
                ViewBag.Welcome = Welcome;
                ViewBag.Departments = departmentsdto;
                ViewBag.UserCount = users;
                ViewBag.Company = company;

                return View();
            }
            return View();
        }
    }
}
