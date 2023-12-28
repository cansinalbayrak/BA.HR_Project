using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class EntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "582ea394-6b21-47ec-af8d-3b3711e4e967");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0567f23e-5824-46ca-a5b9-e739543faf58", 0, "Ankara", new DateTime(2023, 12, 28, 10, 14, 24, 16, DateTimeKind.Local).AddTicks(7720), null, "SeedCompany1", "a1c15778-4ac8-405b-8a53-d059fc997545", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEHFZloYACIjnEFK6eNz6FYx7QnKyyWzbipO32P0sZ/zTbUSbayW5saQ/GD2OMF0XIQ==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "10009640-fff7-472d-8b70-3081587a7959", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0567f23e-5824-46ca-a5b9-e739543faf58");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "582ea394-6b21-47ec-af8d-3b3711e4e967", 0, "Ankara", new DateTime(2023, 12, 26, 14, 37, 21, 493, DateTimeKind.Local).AddTicks(967), null, "SeedCompany1", "5a079008-755a-42f4-82e9-5a6f0a9eb3d4", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEPntCnO9/qvezl6AzE1miB7nfU949+NrewhRBdz0o5A4zUgGeo1aWi2y8srvMJfS8A==", "0", false, "~/mexant/assets/images/Default.jpg", null, null, null, "706b3d47-bcd2-4044-9bef-f7593ab2fe72", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
