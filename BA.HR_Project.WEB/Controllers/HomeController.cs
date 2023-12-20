using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BA.HR_Project.WEB.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeService _employeeManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IAdressService _adressManager;
        private readonly IMapper _mapper;
        
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IEmployeeService employeeManager, ICompanyService companyManager, IDepartmentService departmentManager, IAdressService adressManager, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _employeeManager = employeeManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _adressManager = adressManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var userdto = await _employeeManager.GetAsync(true, x => x.Id == userId);
            var departmentId = userdto.DepartmentId;
            var companyId = userdto.CompanyId;
            var company = await _companyManager.GetAsync(true, x => x.Id == companyId);
            var department = await _departmentManager.GetAsync(true, x => x.Id == departmentId);
            var adress = await _adressManager.GetAsync(true, x => x.AppUserId == userId);

            var userViewModels = _mapper.Map<ListSummarInfoViewModel>(userdto.Context);
            ViewBag.Department = department.Context;
            ViewBag.Company = company.Context;
            ViewBag.Adress = adress.Context;
            return View(userViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}