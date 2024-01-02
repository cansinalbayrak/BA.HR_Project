using BA.HR_Project.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.CompanyId);
            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.DepartmentId);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.BirthPlace).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x=>x.Adress).HasMaxLength(80).IsRequired();

            



            var seedAdmin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin.bilgeadam@bilgeadamboost.com",
                BirthDate = DateTime.Now,
                NormalizedUserName = "ADMIN.BILGEADAM@BILGEADAMBOOST.COM",
                IsTurkishCitizen = true,
                PhoneNumber = "0",
                Email = "admin.bilgeadam@bilgeadamboost.com",
                NormalizedEmail = "ADMIN.BILGEADAM@BILGEADAMBOOST.COM",
                EmailConfirmed = true,
                Name = "Admin",
                Surname = "Bilgeadam",
                SecurityStamp = Guid.NewGuid().ToString(),
                Adress = "Ankara",
                DepartmentId = "SeedDepartment1",
                CompanyId = "SeedCompany1",
                PhotoPath = "/mexant/assets/images/Default.jpg"
        };

            var hasher = new PasswordHasher<AppUser>();
            seedAdmin.PasswordHash = hasher.HashPassword(seedAdmin, "Admin");

            builder.HasData(seedAdmin);
            




        }
    }
}
