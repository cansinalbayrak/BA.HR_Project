using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BA.HR_Project.WEB.Models
{
    public class ResetPasswordViewModel
    {
        public string Id { get; set; }

      
        public string NewPassword { get; set; }

      
        public string ConfirmPassword { get; set; }

       
        public string Code { get; set; }
    }
}
