namespace BA.HR_Project.WEB.Areas.Manager.Models
{
    public class UpdateManagerViewModelcs
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public IFormFile Photo { get; set; }
        public string? PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public bool UseExistingPhoto { get; set; }

        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
       
    }
}
