using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84134fac-7537-4400-b414-d54183bf3df5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d81d411-5340-4117-9aa5-868b8f6a19bb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75f4a959-c543-4793-8aab-0f2947878a2b", 0, "Ankara", new DateTime(2023, 12, 25, 16, 29, 19, 412, DateTimeKind.Local).AddTicks(2508), null, "SeedCompany1", "d4984ed0-0fa6-44a9-bd7a-5a7dbb589b2c", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAECndi+sVD9MnoAV5UHbVbyGRlPthdZMEn7SwLkuRtx8HKl2qHROTfrbr3u3djuO+9Q==", "0", false, null, null, null, null, "e451ed11-0b3c-472b-8b6e-e594a7c5f421", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75f4a959-c543-4793-8aab-0f2947878a2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84134fac-7537-4400-b414-d54183bf3df5", "b931f781-7a83-4fac-9399-6726d5ee6feb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0d81d411-5340-4117-9aa5-868b8f6a19bb", 0, "Ankara", new DateTime(2023, 12, 22, 0, 45, 40, 200, DateTimeKind.Local).AddTicks(9786), null, "SeedCompany1", "e33236d1-c7b6-42b2-84ec-af491b6b3e37", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEMAasIxL23nGv1IhimTUckFGaHwRBEb7DWem/PYA/Ul1iI+DP3EKE15L5VkdQ7HV7Q==", "0", false, null, null, null, null, "50280b53-8971-423a-b39e-5e340df1bfe3", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
