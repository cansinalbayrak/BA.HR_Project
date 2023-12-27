using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        void SendEmail(string reciverEmailAdress, string subject, string mailBody);
    }
}
