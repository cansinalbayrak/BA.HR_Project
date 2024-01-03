using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IMapper _mapper;
        private readonly IExpsenseService _expsenseService;



        public ExpenseController(IExpenseTypeService expenseTypeService, IMapper mapper, IExpenseTypeService expenseService)
        {
            _expenseTypeService = expenseTypeService;
            _mapper = mapper;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RequestExpense() 
        {
            var result = _expenseTypeService.GetAll();
            TempData["ExpenseType"]=result;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense(ExpenseViewModel model)
        {
            if (ModelState.IsValid) 
            {
              var ExpenseDto = _mapper.Map<ExpenseDto>(model);
                var ExpenseAction = _expsenseService.Insert(ExpenseDto);
                if (ExpenseAction.IsCompleted) 
                {
                  return RedirectToAction("Index");
                }


                return RedirectToAction("Index");

            }

            return RedirectToAction ("Index");
        }
    }
}
