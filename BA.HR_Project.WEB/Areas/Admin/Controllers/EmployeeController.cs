using AutoMapper;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

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

        public IActionResult Index()
        {
            return View();
        }




        public async Task<IActionResult> ListEmployee()
        {


























            return View();
        }



        public async Task<IActionResult> AddEmployee()
        {












            return View();
        }





        [HttpPost]
        public async Task<IActionResult> AddEmployee(AppUserViewModel vm)
        {
            return View();





























        }


        public async Task<IActionResult> UpdateEmployee()
        {










            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(AppUserViewModel vm)
        {
            return View();




























        }




        public async Task<IActionResult> DetailsEmployee()
        {
            return View();
































        }


    }
}
