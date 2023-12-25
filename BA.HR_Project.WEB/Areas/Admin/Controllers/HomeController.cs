using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
