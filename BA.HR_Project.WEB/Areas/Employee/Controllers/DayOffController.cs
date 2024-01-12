using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BA.HR_Project.WEB.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee,Admin")]
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
        public async Task<IActionResult> ListDayOff()
        {
            var UserId = _userManager.GetUserId(User);
            var userDayOffs = await _dayOffManager.GetAllDayOff(UserId);
            var waitingDayOffs = await _dayOffManager.WaitingDayOffs(UserId);
            var approvedDayOffs = await _dayOffManager.ApprovedDayOffs(UserId);
            var deniedDayOffs = await _dayOffManager.DeniedDayOffs(UserId);
            var DayOffVm = _mapper.Map<List<DayOffViewModel>>(userDayOffs);
            ViewBag.WaitingDayOffs = waitingDayOffs;
            ViewBag.ApprovedDayOffs = approvedDayOffs;
            ViewBag.DeniedDayOffs = deniedDayOffs;

            return View(DayOffVm);

        }
        [HttpGet]
        public async Task<IActionResult> DemandDayOff()
        {
            var userıd = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userıd);
            var DayOffs = await _dayOffManager.GetAll();
            var annualDayOffs = DayOffs.Context.Where(d => d.StartDate.Year == DateTime.Now.Year && d.AppUserId == user.Id);
            var userDayoff = annualDayOffs.Where(x => x.AppUserId == user.Id && (x.Gender == Gender.Male || x.Gender == Gender.Female)).FirstOrDefault();
            var userDayoff2 = annualDayOffs.Where(x => x.AppUserId == user.Id && x.Gender == Gender.Male).FirstOrDefault();
            var userDayoff3 = annualDayOffs.Where(x => x.AppUserId == user.Id && x.Gender == Gender.Female).FirstOrDefault();
            var userDayoff4 = annualDayOffs.Where(x => x.AppUserId == user.Id && (x.Gender == Gender.Female || x.Gender == Gender.Male)).FirstOrDefault();

            ViewBag.UserDayOff = userDayoff;
            ViewBag.UserDayOff2 = userDayoff2;
            ViewBag.UserDayOff3 = userDayoff3;
            ViewBag.UserDayOff4 = userDayoff4;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DemandDayOff(DayOffViewModel dayOffViewModel)
        {

            var userıd = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userıd);
            var DayOffs = await _dayOffManager.GetAll();
            var annualDayOffs = DayOffs.Context.Where(d => d.StartDate.Year == DateTime.Now.Year && d.AppUserId == user.Id);
            var userDayoff = annualDayOffs.Where(x => x.AppUserId == user.Id && (x.Gender == Gender.Male || x.Gender == Gender.Female)).FirstOrDefault();
            var userDayoff2 = annualDayOffs.Where(x => x.AppUserId == user.Id && x.Gender == Gender.Male).FirstOrDefault();
            var userDayoff3 = annualDayOffs.Where(x => x.AppUserId == user.Id && x.Gender == Gender.Female).FirstOrDefault();
            var userDayoff4 = annualDayOffs.Where(x => x.AppUserId == user.Id && (x.Gender == Gender.Female || x.Gender == Gender.Male)).FirstOrDefault();

            ViewBag.UserDayOff = userDayoff;
            ViewBag.UserDayOff2 = userDayoff2;
            ViewBag.UserDayOff3 = userDayoff3;
            ViewBag.UserDayOff4 = userDayoff4;
            dayOffViewModel.AppUserId = userıd;

            var DayOffDto = _mapper.Map<DayOffDto>(dayOffViewModel);

            var validator = new DayOffViewModelValidator();
            var validationResult = await validator.ValidateAsync(dayOffViewModel);



            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dayOffViewModel);
            }

            var createAction = await _dayOffManager.RequestDayOff(DayOffDto);
            if (createAction.IsSuccess)
            {

                return RedirectToAction("ListDayOff");
            }
            ViewBag.ErrorMessages = createAction.Message;
            return View(dayOffViewModel);

        }



    }
}
