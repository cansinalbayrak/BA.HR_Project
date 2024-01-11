using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Areas.Manager.Models;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BA.HR_Project.WEB.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
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

            
          


            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddManager(AddManagerViewModel model) 
        {
            List<CompanyCustom> allCompanies = _companyService.GetAllCompanyCustomColumn();
            List<string> companyNames = new List<string>();
            for (int i = 0; i < allCompanies.Count; i++)
            {
                companyNames.Add(allCompanies[i].CompanyName + "/" + allCompanies[i].Id);
            }
            ViewBag.CompanyNames = companyNames;

           
            var validator = new AddManagerViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }
           



            if (model.PhotoPath == null)
            {
                model.PhotoPath = "/mexant/assets/images/Default.jpg";
            }
            
            var companyId = model.CompanyId.Split("/")[1];
            model.CompanyId = companyId;

         

            var managerDto = _mapper.Map<AppUserDto>(model);
            var newManager = await _userService.AddManager(managerDto);
            
            if (newManager.IsSuccess)
            {
                
                return RedirectToAction("ListManager");
            }
            ViewBag.ErrorMessages = newManager.Message;

            return View(model);



        }
        public async Task<IActionResult> ListManager() 
        {
            //var managers = await _userManager.GetUsersInRoleAsync("Admin");

            //var listManagerDto = new List<ListManagerDto>();

            //foreach (var manager in managers)
            //{
            //    var company = await _companyService.GetByIdAsync(manager.CompanyId);

            //    var managerDto = new ListManagerDto
            //    {

            //        Name = manager.Name+" "+manager.SecondName,
            //        SurName = manager.Surname+" "+manager.SecondSurname,
            //        CompanyName = company.Context.Name,
            //        PhotoPath = manager.PhotoPath,
            //        PhoneNumber = manager.PhoneNumber,
            //        Email = manager.Email,

            //    };

            //    listManagerDto.Add(managerDto);
            //}
            var managers = await _userManager.GetUsersInRoleAsync("Admin");

            if (managers != null)
            {
                var managerDtos = _mapper.Map<List<ListManagerDto>>(managers);
                var listManagerVm = _mapper.Map<List<ListManagerViewModel>>(managerDtos);

                for (int i = 0; i < managers.Count; i++)
                {
                    var GetrelatedCompanyName = await _companyService.GetByIdAsync(managers[i].CompanyId);
                    if (GetrelatedCompanyName.IsSuccess)
                    {
                        listManagerVm[i].CompanyName = GetrelatedCompanyName.Context.Name;
                    }
                }
                return View(listManagerVm);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateManager(string Id) 
        {
            List<CompanyCustom> allCompanies = _companyService.GetAllCompanyCustomColumn();
            List<string> companyNames = new List<string>();
            for (int i = 0; i < allCompanies.Count; i++)
            {
                companyNames.Add(allCompanies[i].CompanyName + "/" + allCompanies[i].Id);
            }
            ViewBag.CompanyNames = companyNames;

            var manager = await _userManager.FindByIdAsync(Id);
            if (manager != null) 
            {
                var managerDto = _mapper.Map<UpdateManagerDto>(manager);
                var managerVm = _mapper.Map<UpdateManagerViewModelcs>(managerDto);

                var getCompanyName = await _companyService.GetByIdAsync(managerVm.CompanyId);
                if (getCompanyName.IsSuccess)
                {
                    ViewBag.RelatedCompanyName = getCompanyName.Context.Name;
                    return View(managerVm);
                }

            }
            return RedirectToAction("ListManager");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdateManagerViewModelcs model) 
        {
            if (model.PhotoPath == null)
            {
                var getUser = await _userManager.FindByIdAsync(model.Id);
                if (getUser != null) 
                {
                    model.PhotoPath = getUser.PhotoPath;
                //    model.Photo;
                }
                else
                {
                    model.PhotoPath = "/mexant/assets/images/Default.jpg";
                }
            }

            List<CompanyCustom> allCompanies = _companyService.GetAllCompanyCustomColumn();
            List<string> companyNames = new List<string>();
            for (int i = 0; i < allCompanies.Count; i++)
            {
                companyNames.Add(allCompanies[i].CompanyName + "/" + allCompanies[i].Id);
            }
            ViewBag.CompanyNames = companyNames;

          
            var validator = new UpdateManagerValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }

            if (model.Photo != null)
            {
                model.PhotoPath = await HelperMethods.ImageHelper.SaveImageFile(model.Photo);
            }
            

            if (model.PhotoPath.Contains(".jpg") || model.PhotoPath.Contains(".jpeg") || model.PhotoPath.Contains(".png")) 
            {
              
                var companyId = model.CompanyId.Split("/")[1];
                model.CompanyId = companyId;
                var managerDto = _mapper.Map<UpdateManagerDto>(model);
                var manager = _mapper.Map<AppUser>(managerDto);

                var managerAction = await _userService.UpdateForManager(manager);

                if (managerAction.IsSuccess)
                {
                    return RedirectToAction("ListManager");
                }
                ViewBag.ErrorMessages = managerAction.Message ;
                return View(model);
            }

            return View(model);
        }
    }
}

