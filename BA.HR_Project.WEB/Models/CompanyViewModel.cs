using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Enums;
using System.Text.Json.Serialization;

namespace BA.HR_Project.WEB.Models
{
    public class CompanyViewModel
    {
        public string Id { get; set; }
        public CompanyTitle CompanyTitleEnum { get; set; }
        public string Name { get; set; }
        
        
        public string LogoPath { get; set; }

        [JsonIgnore]
        public IFormFile? Photo { get; set; }
        public string ExistingPhotoPath { get; set; }

        [JsonIgnore]
        public FileDetails ExistingPhoto { get; set; }
        public bool RemovePhoto { get; set; }
        public bool UseExistingPhoto { get; set; }



        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public int EmployeeCount { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public DateTime StartUpDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public Activty ActivtyEnum { get; set; }

        [JsonIgnore]
        public List<AppUserViewModel> AppUsers { get; set; }
    }
}
