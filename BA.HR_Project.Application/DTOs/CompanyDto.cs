using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class CompanyDto : IDTO
    {
        public string Id { get; set; }
        public CompanyTitle CompanyTitleEnum { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }

        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public int EmployeeCount { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public DateTime StartUpDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public Activty ActivtyEnum { get; set; }

        public List<AppUserDto> AppUsers { get; set; }
    }
}
