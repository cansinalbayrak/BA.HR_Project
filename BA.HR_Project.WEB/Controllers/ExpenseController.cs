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



        public ExpenseController(IExpenseTypeService expenseTypeService, IMapper mapper, IExpenseTypeService expenseService, UserManager<AppUser> userManager)
        {
            _expenseTypeService = expenseTypeService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RequestExpense() 
        {
            List<ExpenseType> allExpenseTypes = _expenseTypeService.GetAll();
            ViewBag.ExpenseTypes = allExpenseTypes; 
            return View();

            
        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense(ExpenseViewModel model)
        {
            var userId = _userManager.FindByIdAsync(model.Id);
  
              var ExpenseDto = _mapper.Map<ExpenseDto>(model);
                var ExpenseAction = _expsenseService.Insert(ExpenseDto);
                if (ExpenseAction.IsCompletedSuccessfully) 
                {
                  return RedirectToAction("Index");
                }


            return RedirectToAction ("Index");
        }

        
    }
}
