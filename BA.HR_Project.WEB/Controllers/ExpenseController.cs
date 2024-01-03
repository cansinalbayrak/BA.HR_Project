using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense() 
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestExpense(ExpenseViewModel model)
        {

            return View();
        }
    }
}
