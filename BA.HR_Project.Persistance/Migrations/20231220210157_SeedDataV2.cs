using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class SeedDataV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "61e34c72-e6b3-4e88-bd7f-90638748d285", "598a15c6-73f5-46c1-b2bf-5f1390a454a7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressId", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90c12eaa-07ea-4f41-b327-673d4ded387e", 0, "SeedAdress1", new DateTime(2023, 12, 21, 0, 1, 57, 610, DateTimeKind.Local).AddTicks(1566), null, "SeedCompany1", "78586396-6496-4c14-89b5-87851a630605", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEOkdsmlmT8+pNyAh+2p/ENaQ1JZBLgZUODk69MQR5uZYBH10cInAdzJnCcdsu//aGg==", "0", false, null, null, null, null, "ba4b3aba-e3f7-4a0d-bf2d-6769f2500007", null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e34c72-e6b3-4e88-bd7f-90638748d285");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90c12eaa-07ea-4f41-b327-673d4ded387e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b67c49c4-df88-4839-ac1b-e08c72fd2231", "c8313012-1bb4-4aed-a9c7-c83a360857e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdressId", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e70375c3-5412-427c-9bfc-befc1acdd1e9", 0, "SeedAdress1", new DateTime(2023, 12, 20, 23, 54, 31, 768, DateTimeKind.Local).AddTicks(7823), null, "SeedCompany1", "9c88130a-9bbd-4990-85ec-8ece37fa8250", "SeedDepartment1", "admin@bilgeadam.com", true, null, null, true, false, null, "Admin", "ADMIN@BILGEADAM.COM", "ADMIN@BILGEADAM.COM", null, "AQAAAAEAACcQAAAAEF6hYO0k3UC8lUBC/MG/r56df4Yhf6FcR6lmPMOWSVltgTAjkDOl6CSTHWQPVky07A==", "0", false, null, null, null, null, null, null, "Bilgeadam", false, "admin@bilgeadam.com" });
        }
    }
}
