using AutoMapper;
using BA.HR_Project.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BA.HR_Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminHomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminHomeController(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var GetUserAction = await _userManager.GetUserAsync(User);

            if (GetUserAction !=null) 
            {
                var Welcome = GetUserAction.Name + " " + GetUserAction.Surname;
                ViewBag.Welcome = Welcome;
                return View();
            }
            return View();
        }
    }
}
