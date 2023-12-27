using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.Email
{
    public class EmailOption
    {
        public EmailOption ServiceEmailOption { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
