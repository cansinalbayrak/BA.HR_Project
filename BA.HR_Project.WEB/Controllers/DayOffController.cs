using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> ListDayOff()
        {
            var UserId = _userManager.GetUserId(User);
            var userDayOffs = await _dayOffManager.GetAllDayOff(UserId);
            var waitingDayOffs = userDayOffs.Where(x => x.ConfirmStatus == ConfirmStatus.Waiting).OrderBy(x => x.RequestDate).ToList();
            var approvedDayOffs = userDayOffs.Where(x => x.ConfirmStatus == ConfirmStatus.Approved).OrderBy(x => x.RequestDate).ToList();
            var deniedDayOffs = userDayOffs.Where(x => x.ConfirmStatus == ConfirmStatus.Denied).OrderBy(x => x.RequestDate).ToList();
            var DayOffVm = _mapper.Map<List<DayOffViewModel>>(userDayOffs);
            ViewBag.WaitingDayOffs = waitingDayOffs;
            ViewBag.ApprovedDayOffs = approvedDayOffs;
            ViewBag.DeniedDayOffs = deniedDayOffs;

            return View(DayOffVm);

        }
        [HttpGet]
        public async Task<IActionResult> DemandDayOff()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DemandDayOff(DayOffViewModel dayOffViewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            var AppUserDto = _mapper.Map<AppUserDto>(user);
            var DayOfViewModelAppUserVM = _mapper.Map<AppUserViewModel>(AppUserDto);

            dayOffViewModel.AppUser = DayOfViewModelAppUserVM;
            dayOffViewModel.AppUserId = user.Id;

            var DayOffDto = _mapper.Map<DayOffDto>(dayOffViewModel);
            

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
