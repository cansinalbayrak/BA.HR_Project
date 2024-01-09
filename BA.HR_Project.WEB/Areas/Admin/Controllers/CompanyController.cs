using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrasturucture.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using Microsoft.AspNetCore.Authorization;
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
            ViewBag.Photopath = "/mexant/assets/images/defaultCompanyPhoto.png"; ;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyViewModel vm)
        {


            var validator = new CompanyViewModelValidator();
            var validationResult = await validator.ValidateAsync(vm);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(vm);
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


        public IActionResult ListCompany()
        {
            return View();
        }

    }
}
