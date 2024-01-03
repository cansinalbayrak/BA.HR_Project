using BA.HR_Project.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class AppUser:IdentityUser<string> , IEntity
    {
        public AppUser()
        {
            Advances = new();
            DayOffs = new();
        }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Adress { get; set; }
        public int? Salary { get; set; }
        public bool IsActive
        {
            get
            {
                return EndDate==null || EndDate.Value > DateTime.UtcNow.Date;
            }
        }
        public bool IsTurkishCitizen { get; set; }
        public string? IdentityNumber { get; set; }

        public string? PassportNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }

        #region NavProp
        public Company Company { get; set; }
        public Department Department { get; set; }
        public List<Advance> Advances { get; set; }
        public List<DayOff> DayOffs { get; set; }
        #endregion


    }
}
