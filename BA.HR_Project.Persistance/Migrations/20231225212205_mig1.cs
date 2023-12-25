using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75f4a959-c543-4793-8aab-0f2947878a2b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cb27d1f-b73c-4738-b461-deb907dd291c", 0, "Ankara", new DateTime(2023, 12, 26, 0, 22, 5, 340, DateTimeKind.Local).AddTicks(9208), null, "SeedCompany1", "4b37579f-a200-4b82-9b82-7f4d74906fa7", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEOZbkzMUt5G14mGQDR3nC7DNIkeYeL+FluabtQFgV3EImRadj+44U6Me9ZJnU33sYA==", "0", false, null, null, null, null, "3ad7e110-a09a-4fcb-a4e1-c2f1723d94a0", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cb27d1f-b73c-4738-b461-deb907dd291c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75f4a959-c543-4793-8aab-0f2947878a2b", 0, "Ankara", new DateTime(2023, 12, 25, 16, 29, 19, 412, DateTimeKind.Local).AddTicks(2508), null, "SeedCompany1", "d4984ed0-0fa6-44a9-bd7a-5a7dbb589b2c", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAECndi+sVD9MnoAV5UHbVbyGRlPthdZMEn7SwLkuRtx8HKl2qHROTfrbr3u3djuO+9Q==", "0", false, null, null, null, null, "e451ed11-0b3c-472b-8b6e-e594a7c5f421", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
