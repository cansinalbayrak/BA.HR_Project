using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class AddDayOffv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abbcc463-11c1-4e99-aee9-f403a307f6d3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "57c0c259-dcda-4ac1-9f83-7b53cbda4f95", 0, "Ankara", new DateTime(2024, 1, 2, 17, 7, 11, 573, DateTimeKind.Local).AddTicks(2003), null, "SeedCompany1", "34e803b1-f725-43e7-a7d7-8563272fe279", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAELeaXtih3jF5uClGomsNLmf6Ai0SSTyw5NNDgEe+ZB9qMK7QXlTIK1DWyR6qm86ibg==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "3f6b5e91-e4ab-4e26-877d-5d85d78e2ddf", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57c0c259-dcda-4ac1-9f83-7b53cbda4f95");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "abbcc463-11c1-4e99-aee9-f403a307f6d3", 0, "Ankara", new DateTime(2024, 1, 2, 16, 32, 59, 307, DateTimeKind.Local).AddTicks(2927), null, "SeedCompany1", "dc5e644d-954d-4785-a323-ae658bebcd12", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEHqhZIi0Zv/VJybotPW2L0R1u8WAqKk74KfYdBR0xJvUQ3L5m+GsmauyjsyQePm99g==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "2aa9c3a2-d2eb-4d34-8d37-573066b8d037", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });
        }
    }
}
