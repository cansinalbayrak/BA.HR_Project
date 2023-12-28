namespace BA.HR_Project.WEB.Models
{
    public class AppUserUpdateForEmployeeVM
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int MyProperty { get; set; }
        public string? PhotoPath { get; set; }
        public IFormFile? Photo { get; set; }
        public string ExistingPhotoPath { get; set; }
        public FileDetails ExistingPhoto { get; set; }
        public bool RemovePhoto { get; set; }
        public bool UseExistingPhoto { get; set; }

    }
    public class FileDetails
    {
        public string Path { get; set; }
        // Diğer dosya detayları eklenebilir
    }
}
