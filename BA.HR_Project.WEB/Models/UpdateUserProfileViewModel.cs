using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class UpdateUserProfileViewModel
    {
        public string Id { get; set; }
        public string? PhotoPath { get; set; }
        public IFormFile? Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepantmentId { get; set; }
        public string Adress { get; set; }
        public string ExistingPhotoPath { get; set; }
        public FileDetails ExistingPhoto { get; set; }
    }
    public class FileDetails
    {
        public string Path { get; set; }
        // Diğer dosya detayları eklenebilir
    }
}
