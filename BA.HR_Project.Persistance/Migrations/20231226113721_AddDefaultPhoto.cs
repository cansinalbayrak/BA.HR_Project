using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class AddDefaultPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cb27d1f-b73c-4738-b461-deb907dd291c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "582ea394-6b21-47ec-af8d-3b3711e4e967", 0, "Ankara", new DateTime(2023, 12, 26, 14, 37, 21, 493, DateTimeKind.Local).AddTicks(967), null, "SeedCompany1", "5a079008-755a-42f4-82e9-5a6f0a9eb3d4", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEPntCnO9/qvezl6AzE1miB7nfU949+NrewhRBdz0o5A4zUgGeo1aWi2y8srvMJfS8A==", "0", false, "~/mexant/assets/images/Default.jpg", null, null, null, "706b3d47-bcd2-4044-9bef-f7593ab2fe72", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "582ea394-6b21-47ec-af8d-3b3711e4e967");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cb27d1f-b73c-4738-b461-deb907dd291c", 0, "Ankara", new DateTime(2023, 12, 26, 0, 22, 5, 340, DateTimeKind.Local).AddTicks(9208), null, "SeedCompany1", "4b37579f-a200-4b82-9b82-7f4d74906fa7", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEOZbkzMUt5G14mGQDR3nC7DNIkeYeL+FluabtQFgV3EImRadj+44U6Me9ZJnU33sYA==", "0", false, null, null, null, null, "3ad7e110-a09a-4fcb-a4e1-c2f1723d94a0", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
