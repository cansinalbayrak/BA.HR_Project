using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Areas.Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Manager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public ManagerController(IAppUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddManager() 
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddManager(AddManagerViewModel model) 
        {
            if (model.PhotoPath == null)
            {
                model.PhotoPath = "/mexant/assets/images/Default.jpg";
            }

            var managerDto = _mapper.Map<AddManagerDto>(model);
            var newManager = await _userService.AddManager(managerDto);
            if (newManager != null) 
            {
              return RedirectToAction("ListManager");
            
            }
            return RedirectToAction("Warning", "Home");


           
        }
    }
}
