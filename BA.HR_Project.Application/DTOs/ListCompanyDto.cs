using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ListCompanyDto : IDTO
    {
        public string LogoPath { get; set; }
        public CompanyTitle CompanyTitleEnum { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
