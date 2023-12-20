using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class MigSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae05658c-ba71-4905-a0f2-78b1e6bf9962");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db7dfc41-56b4-416e-97a1-eed3713618cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b67c49c4-df88-4839-ac1b-e08c72fd2231", "c8313012-1bb4-4aed-a9c7-c83a360857e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressId", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e70375c3-5412-427c-9bfc-befc1acdd1e9", 0, "SeedAdress1", new DateTime(2023, 12, 20, 23, 54, 31, 768, DateTimeKind.Local).AddTicks(7823), null, "SeedCompany1", "9c88130a-9bbd-4990-85ec-8ece37fa8250", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEF6hYO0k3UC8lUBC/MG/r56df4Yhf6FcR6lmPMOWSVltgTAjkDOl6CSTHWQPVky07A==", "0", false, null, null, null, null, null, null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b67c49c4-df88-4839-ac1b-e08c72fd2231");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e70375c3-5412-427c-9bfc-befc1acdd1e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae05658c-ba71-4905-a0f2-78b1e6bf9962", "ab7a2143-d092-46e6-bc71-9dacbdb33d55", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressId", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "db7dfc41-56b4-416e-97a1-eed3713618cd", 3, "SeedAdress1", new DateTime(2023, 12, 20, 17, 8, 49, 76, DateTimeKind.Local).AddTicks(4208), null, "SeedCompany1", "89d214d8-ed5c-44ac-9092-ef284b05f60c", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "Admin", "0", true, null, null, null, null, "", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
