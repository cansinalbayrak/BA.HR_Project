using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class DayOffController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserManager;
        private readonly IDayOffService _dayOffManager;
        private readonly IMapper _mapper;

        public DayOffController(UserManager<AppUser> userManager, IAppUserService appUserManager, IDayOffService dayOffManager, IMapper mapper)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _dayOffManager = dayOffManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _dayOffManager.GetAll();

            if (result.IsSuccess)
            {
                return View(result.Context);
            }

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DayOffViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dayOffDto = _mapper.Map<DayOffDto>(model);

                var result = await _dayOffManager.Insert(dayOffDto);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index"); 
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
