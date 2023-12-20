using BA.HR_Project.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class Adress:IEntity
    {
        public Adress(string city, string district, string street, string zipCode)
        {
            if (Id ==null)
            {
                Id = Guid.NewGuid().ToString();
            }
            
            City = city;
            District = district;
            Street = street;
            ZipCode = zipCode;
        }
        public string Id { get; set; }
        public string City { get; set; } 
        public string District { get; set; } 
        public string Street { get; set; } 
        public string ZipCode { get; set; }

        #region NavProp
        public AppUser AppUser { get; set; }

        #endregion
    }
}
