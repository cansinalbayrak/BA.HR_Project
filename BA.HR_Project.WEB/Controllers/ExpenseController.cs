using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BA.HR_Project.WEB.Controllers
{
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
            List<ExpenseType> allExpenseTypes = _expenseTypeService.GetAll();
            List<string> expenseNames = new List<string>();
            for (int i = 0; i < allExpenseTypes.Count; i++)
            {
                expenseNames.Add(allExpenseTypes[i].ExpenseName);
            }

            ViewBag.ExpenseTypes = expenseNames;

            return View();


        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense(ExpenseViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            model.AppUserId = userId;

            var ExpenseDto = _mapper.Map<ExpenseDto>(model);
            var ExpenseAction = await _expsenseService.RequestExpense(ExpenseDto);

            //var ExpenseAction = await _expsenseService.Insert(ExpenseDto);
            if (ExpenseAction.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }




            return View(model);
        }


    }
}
