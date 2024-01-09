using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrasturucture.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyManager;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyManager, IMapper mapper)
        {
            _companyManager = companyManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddCompany()
        {
            ViewBag.Photopath = "/mexant/assets/images/defaultCompanyPhoto.png";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyViewModel vm)
        {
            var LogoPath = await HelperMethods.ImageHelper.SaveImageFile(vm.Photo);
            vm.LogoPath = LogoPath;

            if (vm.LogoPath==null)
            {
                vm.LogoPath = "/mexant/assets/images/defaultCompanyPhoto.png";
            }

            vm.Id = Guid.NewGuid().ToString();
            var CompanyDto = _mapper.Map<CompanyDto>(vm);
            var createCompanyAction = await _companyManager.Insert(CompanyDto);
            if (createCompanyAction.IsSuccess)
            {
                return RedirectToAction("ListCompany");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListCompany()
        {
            var GetcompanysDto = await _companyManager.GetAll();
            if (GetcompanysDto.IsSuccess)
            {
                var companysVM = _mapper.Map<List<CompanyViewModel>>(GetcompanysDto.Context);
                return View(companysVM);
            }
            return View();

        }

    }
}
