using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Managers.Concrate;
using BA.HR_Project.Infrastructure.Services.Concrate;
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
    public class ExpenseController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IMapper _mapper;
        private readonly IExpsenseService _expsenseService;
        private readonly UserManager<AppUser> _userManager;



        public ExpenseController(IExpenseTypeService expenseTypeService, IMapper mapper, UserManager<AppUser> userManager, IExpsenseService expsenseService)
        {
            _expenseTypeService = expenseTypeService;
            _mapper = mapper;
            _userManager = userManager;
            _expsenseService = expsenseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RequestExpense()
        {
            List<ExpenseTypeCustom> allExpenseTypes = _expenseTypeService.GetAllCustomColumn();
            List<string> expenseNames = new List<string>();
            for (int i = 0; i < allExpenseTypes.Count; i++)
            {
                expenseNames.Add(allExpenseTypes[i].Name + "/" + allExpenseTypes[i].Id);
            }

            ViewBag.ExpenseTypes = expenseNames;


            //var selectedItem = allExpenseTypes.FirstOrDefault();
            //if (selectedItem != null)
            //{
            //    var minPrice = _expenseTypeService.GetMinPrice(selectedItem.Id);
            //    ViewBag.MinPrice = minPrice;
            //    var maxPrice = _expenseTypeService.GetMaxPrice(selectedItem.Id);
            //    ViewBag.MaxPrice = maxPrice;

            //}

            return View();


        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense(ExpenseViewModel model)
        {
            List<ExpenseTypeCustom> allExpenseTypes = _expenseTypeService.GetAllCustomColumn();
            List<string> expenseNames = new List<string>();
            for (int i = 0; i < allExpenseTypes.Count; i++)
            {
                expenseNames.Add(allExpenseTypes[i].Name + "/" + allExpenseTypes[i].Id);
            }

            ViewBag.ExpenseTypes = expenseNames;
            var validator = new ExpenseViewModelValidator();
            var validationRsult = await validator.ValidateAsync(model);

            if (!validationRsult.IsValid)
            {
                foreach (var error in validationRsult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
                return View(model);
            }
            var userId = _userManager.GetUserId(User);
            model.AppUserId = userId;

            var filePath = await HelperMethods.ImageHelper.SaveImageFile(model.File);
            model.FilePath = filePath;
            if (filePath.Contains(".jpeg") || filePath.Contains(".jpg") || filePath.Contains(".png") || filePath.Contains(".pdf"))
            {
                var expenseId = model.ExpenseTypeId.Split('/')[1];

                var expenseName = model.ExpenseTypeId.Split('/')[0];
                var expenseName1 = expenseName.Split(" ")[0];
                model.ExpenseName = expenseName1;
                model.ExpenseTypeId = expenseId;

                var ExpenseDto = _mapper.Map<ExpenseDto>(model);
                var ExpenseAction = await _expsenseService.RequestExpense(ExpenseDto);
                if (ExpenseAction.IsSuccess)
                {
                    return RedirectToAction("ExpenseList");
                }
                ViewBag.ErrorMassages = ExpenseAction.Message;
                return View(model);

            }
            else
            {
                ViewBag.FileError = "File type is not correct";
                return View(model);
            }









        }
        public async Task<IActionResult> ExpenseList()
        {
            var userId = _userManager.GetUserId(User);
            var AllExpenseDto = await _expsenseService.GetAllExpenses(userId);
            var waitingExpenses = AllExpenseDto.Where(e => e.ConfirmStatus == ConfirmStatus.Waiting).OrderBy(e => e.RequestDate).ToList();
            var dinedExpenses = AllExpenseDto.Where(e => e.ConfirmStatus == ConfirmStatus.Denied).OrderBy(e => e.RequestDate).ToList();
            var approvedExpenses = AllExpenseDto.Where(e => e.ConfirmStatus == ConfirmStatus.Approved).OrderBy(e => e.RequestDate).ToList();


            var expenseVm = _mapper.Map<List<ExpenseViewModel>>(AllExpenseDto);
            ViewBag.WaitingExpenses = waitingExpenses;
            ViewBag.DinedExpenses = dinedExpenses;
            ViewBag.AprroveExpenses = approvedExpenses;
            return View(expenseVm);


        }


    }
}
