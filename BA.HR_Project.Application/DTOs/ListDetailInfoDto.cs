using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ListDetailInfoDto : IDTO
    {
        public CompanyDto Company { get; set; }
        public DepartmentDto Department { get; set; }
        
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsTurkishCitizen { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string Adress { get; set; }

    }


   
}
