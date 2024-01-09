using BA.HR_Project.Domain.Enums;

namespace BA.HR_Project.WEB.Models
{
    public class ListCompanyViewModel
    {
        public string  LogoPath { get; set; }
        public CompanyTitle CompanyTitleEnum { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
