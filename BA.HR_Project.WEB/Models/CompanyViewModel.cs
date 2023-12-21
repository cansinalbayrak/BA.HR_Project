using BA.HR_Project.Application.DTOs;

namespace BA.HR_Project.WEB.Models
{
    public class CompanyViewModel
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }

        public AppUserViewModel AppUser { get; set; }
    }
}
