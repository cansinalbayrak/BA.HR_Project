using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class UpdateUserProfileViewModel
    {
        public string Id { get; set; }
        public string? PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public List<Adress> Adresses { get; set; }
    }
}
