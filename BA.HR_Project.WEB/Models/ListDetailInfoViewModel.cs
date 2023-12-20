using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class ListDetailInfoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsTurkishCitizen { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public List<Adress> Adresses { get; set; }
    }
}
