using BA.HR_Project.Domain.Entities;
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
                Name = "BilgeAdam",
                LogoPath = "BilgeAdamınLogosunuEkle",

            });
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
