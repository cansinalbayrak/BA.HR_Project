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
        private string? _identityNo;
        private string? _passportNo;


        public AppUser()
        {

        }

        public AppUser(bool isTurkishCitizen)
        {
            IsTurkishCitizen = isTurkishCitizen;
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
        public int? Salary { get; set; }
        public bool IsActive
        {
            get
            {
                return EndDate==null || EndDate.Value > DateTime.UtcNow.Date;
            }
        }
        public bool IsTurkishCitizen { get; set; }
        public string? IdentityNumber
        {
            get
            {
                return IsTurkishCitizen ? _identityNo : null;
            }
            set
            {
                if (IsTurkishCitizen)
                {
                    _identityNo = value;
                }
            }
        }
        public string? PassportNumber
        {
            get
            {
                return IsTurkishCitizen ? null : _passportNo;
            }
            set
            {
                if (!IsTurkishCitizen)
                {
                    _passportNo = value;
                }
            }
        }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string AdressId { get; set; }

        #region NavProp
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Adress Adress { get; set; }

        #endregion


    }
}
