using BA.HR_Project.Infrasturucture.RequestResponse;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Warning()
        {
            var exception = HttpContext.Items["Exception"] as Response;
            return View(exception);
        }
    }
}
