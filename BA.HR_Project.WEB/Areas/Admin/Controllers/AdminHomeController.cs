using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        [HttpGet("/Admin/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
