using Microsoft.AspNetCore.Mvc;

namespace BA.HR_Project.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeService _employeeManager;
        private readonly ICompanyService _companyManager;
        private readonly IDepartmentService _departmentManager;
        private readonly IAdressService _adressManager;
        private readonly IMapper _mapper;

        public EmployeeController(UserManager<AppUser> userManager, IEmployeeService employeeManager, ICompanyService companyManager, IDepartmentService departmentManager, IAdressService adressManager, IMapper mapper)
        {
            _userManager = userManager;
            _employeeManager = employeeManager;
            _companyManager = companyManager;
            _departmentManager = departmentManager;
            _adressManager = adressManager;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Detail()
        {
            var userId = _userManager.GetUserId(User);
            var userdto = await _employeeManager.GetAsync(true, x => x.Id == userId);
            var departmentId = userdto.DepartmentId;
            var companyId = userdto.CompanyId;
            var company = await _companyManager.GetAsync(true, x => x.Id == companyId);
            var department = await _departmentManager.GetAsync(true, x => x.Id == departmentId);
            var adress = await _adressManager.GetAsync(true, x => x.AppUserId == userId);

            var userViewModels = _mapper.Map<ListDetailInfoViewModel>(userdto.Context);
            ViewBag.DepartmentD = department.Context;
            ViewBag.CompanyD = company.Context;
            ViewBag.AdressD = adress.Context;
            return View(userViewModels);

        }
        public IActionResult Update()
        {
            var userId = _userManager.GetUserId(User);
            var userdto = await _employeeManager.GetAsync(true, x => x.Id == userId);
            var userViewModels = _mapper.Map<UpdateUserProfileViewModel>(userdto.Context);
            return View(userViewModels);
        }
        [HttpPost]
        public IActionResult Update(UpdateUserProfileViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UpdateUserProfile>(vm);

                await _employeeManager.Update(userDto);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
