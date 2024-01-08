using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new
            {
                Id="SeedCompany1",
                CompanyTitleEnum = CompanyTitle.LTD,
                Name = "BilgeAdam",
                LogoPath = "/images/akademilogo-yatay.webp",
                Phone = "1234567890",
                Adress = "Bilkent-Ankara",
                Mail = "info@bilgeadamboost.com",
                EmployeeCount = 0,
                MersisNo = "MersisNo",
                TaxNo = "TaxNo",
                TaxOffice = "Bilken Vergi Dairesi",
                StartUpDate = DateTime.Now,
                ContractStartDate = DateTime.Now,
                ContractEndDate = DateTime.Now,
                ActivtyEnum = Activty.Active,
                

            });
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
