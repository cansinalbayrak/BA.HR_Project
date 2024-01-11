using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ListManagerDto : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string SurName { get; set; }
        public string? SecondSurName { get; set; }
        public string CompanyName { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        
    }
}

