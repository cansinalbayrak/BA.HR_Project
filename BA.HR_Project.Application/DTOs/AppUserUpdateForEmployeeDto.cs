using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class AppUserUpdateForEmployeeDto : IDTO
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string? PhotoPath { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
