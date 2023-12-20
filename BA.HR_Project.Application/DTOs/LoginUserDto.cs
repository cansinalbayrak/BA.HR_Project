using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class LoginUserDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
