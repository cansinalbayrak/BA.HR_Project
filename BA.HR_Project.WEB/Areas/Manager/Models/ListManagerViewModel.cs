namespace BA.HR_Project.WEB.Areas.Manager.Models
{
    public class ListManagerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string SurName { get; set; }
        public string? SecondSurName { get; set; }
        public string CompanyName { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
        public string CompanyId { get; set; }
       
    }
}
