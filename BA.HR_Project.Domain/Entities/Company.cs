using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Name { get; set; }
        public string LogoPath { get; set; }

        #region NavProp
        public List<AppUser> AppUsers { get; set; }

        #endregion
    }
}
