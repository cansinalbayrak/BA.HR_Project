using BA.HR_Project.Application.Email;
using BA.HR_Project.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BA.HR_Project.Infrastructure.Managers.Abstract
{
    public class EmailManager : IEmailService
    {
        private readonly EmailOption _option;

        public EmailManager(IOptions<EmailOption> option)
        {
            _option = option.Value;
        }

        public void SendEmail(string reciverEmailAdress, string subject, string mailBody)
        {
            try
            {
                var smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = smtpClient.DeliveryMethod;
                smtpClient.UseDefaultCredentials = false;


                smtpClient.Host = _option.ServiceEmailOption.Host;
                smtpClient.Port = _option.ServiceEmailOption.Port;
                smtpClient.Credentials = new NetworkCredential(_option.ServiceEmailOption.Email, _option.ServiceEmailOption.Password);


                var mailMassage = new MailMessage();
                mailMassage.From = new MailAddress(_option.ServiceEmailOption.Email);

                mailMassage.To.Add(reciverEmailAdress);
                mailMassage.Subject = subject;
                mailMassage.Body = mailBody;
                mailMassage.IsBodyHtml = true;

                smtpClient.Send(mailMassage);

            }
            catch (Exception)
            {

                Console.WriteLine("Error");
            }
        }


    }
}
