using BA.HR_Project.Application.DTOs;

namespace BA.HR_Project.WEB.Models
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }

        public List<AppUserViewModel> AppUsers { get; set; }
    }
}
