using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.WEB.Models;
using BA.HR_Project.WEB.ModelValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BA.HR_Project.WEB.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee,Admin")]
    public class AdvanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdvanceService _advanceService;
        private readonly IMapper _mapper;

        public AdvanceController(UserManager<AppUser> userManager, IAdvanceService advanceService, IMapper mapper)
        {
            _userManager = userManager;
            _advanceService = advanceService;
            _mapper = mapper;
        }
        public IActionResult DemandAdvance()
        {
            var advanceCurrency = GetAdvanceCurrencyList();
            ViewBag.AdvanceCurrency = advanceCurrency;
            var advanceType = GetAdvanceTypeList();
            ViewBag.AdvanceType = advanceType;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DemandAdvance(AdvanceViewModel vm)
        {
            var advanceCurrency = GetAdvanceCurrencyList();
            ViewBag.AdvanceCurrency = advanceCurrency;
            var advanceType = GetAdvanceTypeList();
            ViewBag.AdvanceType = advanceType;

            var validator = new AdvanceViewModelValidator();
            var validationResult = await validator.ValidateAsync(vm);



            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(vm);
            }

            var userId = _userManager.GetUserId(User);
            vm.AppUserId = userId;
            var advanceDto = _mapper.Map<AdvanceDto>(vm);
            var createAction = await _advanceService.CreateAvance(advanceDto);
            if (createAction.IsSuccess)
            {
                return RedirectToAction("ListAdvance");
            }
            ViewBag.ErrorMessages = createAction.Message;
            return View(vm);
        }
        public async Task<IActionResult> ListAdvance()
        {
            var userId = _userManager.GetUserId(User);
            var allAdvancesDto = await _advanceService.GetAllAvance(userId);
            var waitingAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Waiting).OrderBy(x => x.RequestDate).ToList();
            var approvedAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Approved).OrderBy(x => x.RequestDate).ToList();
            var deniedAdvances = allAdvancesDto.Where(x => x.ConfirmStatus == ConfirmStatus.Denied).OrderBy(x => x.RequestDate).ToList();

            var advancesVm = _mapper.Map<List<AdvanceViewModel>>(allAdvancesDto);
            ViewBag.WaitingAdvances = waitingAdvances;
            ViewBag.ApprovedAdvances = approvedAdvances;
            ViewBag.DeniedAdvances = deniedAdvances;

            return View(advancesVm);
        }
        private List<SelectListItem> GetAdvanceCurrencyList()
        {
            var currencies = Enum.GetValues(typeof(Currency))
                                 .Cast<Currency>()
                                 .Select(x => new SelectListItem
                                 {
                                     Text = x.ToString(),
                                     Value = ((int)x).ToString()
                                 })
                                 .ToList();

            return currencies;
        }

        private List<SelectListItem> GetAdvanceTypeList()
        {
            var types = Enum.GetValues(typeof(AdvanceType))
                                 .Cast<AdvanceType>()
                                 .Select(x => new SelectListItem
                                 {
                                     Text = x.ToString(),
                                     Value = ((int)x).ToString()
                                 })
                                 .ToList();

            return types;
        }
    }
}
