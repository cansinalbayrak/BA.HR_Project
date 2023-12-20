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
        public int CompanyId { get; set; }
        public int DepantmentId { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public List<Adress> Adresses { get; set; }
    }
}
