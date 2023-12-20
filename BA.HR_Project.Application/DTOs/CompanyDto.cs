using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class CompanyDto : IDTO
    {

        public string Name { get; set; }
        public string LogoPath { get; set; }

        public List<AppUserDto> AppUsers { get; set; }
    }
}
