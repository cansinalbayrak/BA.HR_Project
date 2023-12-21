using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class UpdateUserProfileViewModel
    {
        public string Id { get; set; }
        public string? PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepantmentId { get; set; }
        public AdressViewModel Adress { get; set; }
        //public string GetAddress()
        //{
        //    return Adress.City + " , " + Adress.Street + " , " + Adress.ZipCode;
        //}
    }
}
