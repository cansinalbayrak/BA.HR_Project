using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
