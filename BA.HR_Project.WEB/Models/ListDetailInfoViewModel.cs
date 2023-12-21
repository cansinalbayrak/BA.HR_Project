using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;

namespace BA.HR_Project.WEB.Models
{
    public class ListDetailInfoViewModel
    {

        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsTurkishCitizen { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string AdressId { get; set; }
        public CompanyViewModel Company { get; set; }
        public DepartmentViewModel Department { get; set; }
        public AdressViewModel Adress { get; set; }

        //public string GetAddress()
        //{
        //    return Adress.City + " , " + Adress.Street + " , " + Adress.ZipCode;
        //}
        //public string GetCompany()
        //{
        //    return Company.Name;
        //}
        //public string GetDepartment()
        //{
        //    return Department.Name;
        //}

        //public string GetAddress
        //{
        //    get
        //    {
        //        return Adress.City + " , " + Adress.Street + " , " + Adress.ZipCode;
        //    }

        //}
    }
}
