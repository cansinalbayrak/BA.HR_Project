using BA.HR_Project.Domain.Common;
using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class Company:IEntity
    {
        public Company()
        {
            if (Id == null)
            {
                Id = Guid.NewGuid().ToString();
            }

            AppUsers = new();
        }
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


        #region NavProp
        public List<AppUser> AppUsers { get; set; }

        #endregion
    }
}
