using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class ListSummarInfoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? PhotoPath { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepantmentId { get; set; }
        public string Adress { get; set; }
        public string ExistingPhotoPath { get; set; }
        public FileDetails ExistingPhoto { get; set; }
        public CompanyViewModel Company { get; set; }
        public DepartmentViewModel Department { get; set; }

    }
}
