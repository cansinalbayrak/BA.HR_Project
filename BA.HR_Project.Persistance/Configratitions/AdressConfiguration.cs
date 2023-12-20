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
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {

            builder.HasData(new
            {
                Id="SeedAdress1",
                City = "Ankara",
                District = "Çankaya",
                Street ="KüçükEsat",
                ZipCode="06100"

            });

            builder.Property(x => x.Street).HasMaxLength(50).IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).IsRequired();
            builder.Property(x => x.District).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(50).IsRequired();
        }
    }
}
