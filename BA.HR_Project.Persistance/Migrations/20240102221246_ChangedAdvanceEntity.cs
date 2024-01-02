using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class ChangedAdvanceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7345270-d778-4904-afa4-010c770d5936");

            migrationBuilder.DropColumn(
                name: "ExpenseMaxPrice",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseMinPrice",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Advances");

            migrationBuilder.AddColumn<float>(
                name: "ExpenseMaxPrice",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExpenseMinPrice",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e61de148-9b2a-4358-b28e-0d04e3ab6331", 0, "Ankara", new DateTime(2024, 1, 3, 1, 12, 46, 632, DateTimeKind.Local).AddTicks(99), null, "SeedCompany1", "5085d05d-4d2e-4bfd-9fd7-e722846f4d31", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEFsUNdEwYkA1h8r2eP3XRoFGoihk2BRjKZaZJkU2c+gGlI2SuBZyVNyB4wRYivDTFQ==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "5ca42047-9b2b-4aa7-abf9-1e8e44359321", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e61de148-9b2a-4358-b28e-0d04e3ab6331");

            migrationBuilder.DropColumn(
                name: "ExpenseMaxPrice",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "ExpenseMinPrice",
                table: "ExpenseTypes");

            migrationBuilder.AddColumn<float>(
                name: "ExpenseMaxPrice",
                table: "Expenses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExpenseMinPrice",
                table: "Expenses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RemainingAmount",
                table: "Advances",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7345270-d778-4904-afa4-010c770d5936", 0, "Ankara", new DateTime(2024, 1, 2, 17, 26, 33, 792, DateTimeKind.Local).AddTicks(2841), null, "SeedCompany1", "40d2aba3-fd61-494e-bef7-5c3f804a3ecb", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEDdqSc7wzJyTdff941uIiNjy0s8AZvprpNXL8kB4c7tICOxcqSiiZps7DdN3vb3/kQ==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "a93258eb-783c-4ff5-90a5-90a431b0a063", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });
        }
    }
}
