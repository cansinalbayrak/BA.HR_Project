using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class UpdateUserProfile : IDTO
    {
        //public string Id { get; set; }
        //public string PhotoPath { get; set; }
        //public string PhoneNumber { get; set; }
        public AppUserUpdateUserProfile appUserUpdateUserProfile { get; set; }
        public AdressDto Adress { get; set; }
    }

    public class AppUserUpdateUserProfile
    {
        public string Id { get; set; }
        public string PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
    }
}
