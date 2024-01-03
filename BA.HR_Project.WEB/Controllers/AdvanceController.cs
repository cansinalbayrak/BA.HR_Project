using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Abstract;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class AdvanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdvanceService _advanceService;

        public AdvanceController(UserManager<AppUser> userManager, IAdvanceService advanceService)
        {
            _userManager = userManager;
            _advanceService = advanceService;
        }

        public async Task<IActionResult> DemandAdvance()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DemandAdvance(AdvanceViewModel vm)
        {

            return View();
        }
    }
}
