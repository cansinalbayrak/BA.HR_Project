using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class CompanyEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c0af26c-db2d-4c4b-bfb4-95e0c0f53ca1");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "027064cb-444e-44d3-82e5-ef7cdf8dedab");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "1c8e5553-d53f-41de-839e-1b3a206a4836");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "7d3a14ee-d61a-40c0-b6c8-2fca7c38593d");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "89f00d46-a1b7-4a9d-a20a-b397cdfc7f9b");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "a27a5821-030b-43f3-8f49-db23def4a950");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "ceb2c93d-8336-4ceb-b1a5-83ce2e2d372f");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "db1a9bd5-fc1f-45cf-82f0-2e5105ffbdf0");

            migrationBuilder.AddColumn<int>(
                name: "ActivtyEnum",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyTitleEnum",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractEndDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractStartDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCount",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MersisNo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartUpDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TaxNo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxOffice",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29f95c48-9b2e-40be-bae4-fe255cff0f47", 0, "Ankara", new DateTime(2024, 1, 8, 16, 19, 19, 575, DateTimeKind.Local).AddTicks(8620), null, "SeedCompany1", "d28e442a-ccf9-40a0-b723-bf217ac36ad9", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEO0su3oS42E6zcGAzDduQmUxjlu0iqRWxD/cg16j+j8SXL8kvhwPDZ8uNbGERR9E3g==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "d18acbc1-c558-45ff-a01a-78edd921d099", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "SeedCompany1",
                columns: new[] { "ActivtyEnum", "Adress", "CompanyTitleEnum", "ContractEndDate", "ContractStartDate", "Mail", "MersisNo", "Phone", "StartUpDate", "TaxNo", "TaxOffice" },
                values: new object[] { 1, "Bilkent-Ankara", 1, new DateTime(2024, 1, 8, 16, 19, 19, 577, DateTimeKind.Local).AddTicks(5149), new DateTime(2024, 1, 8, 16, 19, 19, 577, DateTimeKind.Local).AddTicks(5149), "info@bilgeadamboost.com", "MersisNo", "1234567890", new DateTime(2024, 1, 8, 16, 19, 19, 577, DateTimeKind.Local).AddTicks(5131), "TaxNo", "Bilken Vergi Dairesi" });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseMaxPrice", "ExpenseMinPrice", "ExpenseName" },
                values: new object[,]
                {
                    { "058417cb-87e5-4dae-9b3b-e5e5b9c889dd", 4000m, 400m, "Food and Drink" },
                    { "0b43aa87-5fa2-4f93-b35e-729e04ebf818", 1000m, 1m, "Others" },
                    { "0c805842-9de7-4939-806a-05d6392bc55f", 15000m, 1000m, "Accomodation" },
                    { "6bebe374-af61-47f2-9435-c8b68b9e6c83", 15000m, 10000m, "Education" },
                    { "86902496-1a48-466e-94f4-d3301b674a1a", 20000m, 1000m, "Research and Devolopment" },
                    { "9effc68b-af09-447d-9c0d-8bb9f2f462bb", 10000m, 1000m, "Marketing and Advertising Expenditures" },
                    { "f01f0120-82bd-4e07-aca8-8042b3d2c2fb", 5000m, 1000m, "Travel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f95c48-9b2e-40be-bae4-fe255cff0f47");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "058417cb-87e5-4dae-9b3b-e5e5b9c889dd");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "0b43aa87-5fa2-4f93-b35e-729e04ebf818");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "0c805842-9de7-4939-806a-05d6392bc55f");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "6bebe374-af61-47f2-9435-c8b68b9e6c83");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "86902496-1a48-466e-94f4-d3301b674a1a");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "9effc68b-af09-447d-9c0d-8bb9f2f462bb");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "f01f0120-82bd-4e07-aca8-8042b3d2c2fb");

            migrationBuilder.DropColumn(
                name: "ActivtyEnum",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyTitleEnum",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContractEndDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContractStartDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EmployeeCount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MersisNo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StartUpDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TaxNo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TaxOffice",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c0af26c-db2d-4c4b-bfb4-95e0c0f53ca1", 0, "Ankara", new DateTime(2024, 1, 6, 1, 35, 41, 842, DateTimeKind.Local).AddTicks(2913), null, "SeedCompany1", "02d0c6e1-11a9-45ef-9f4d-413fd38bc5e7", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEFfsewm7/uIKuQGrOWvXgGc0LZehBCxfKiBOTSr2sCnUdNzz9scbubqtmwegF3GJcA==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "afd0fc77-c3d4-45d0-a791-42844e041e0f", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseMaxPrice", "ExpenseMinPrice", "ExpenseName" },
                values: new object[,]
                {
                    { "027064cb-444e-44d3-82e5-ef7cdf8dedab", 15000m, 1000m, "Accomodation" },
                    { "1c8e5553-d53f-41de-839e-1b3a206a4836", 10000m, 1000m, "Marketing and Advertising Expenditures" },
                    { "7d3a14ee-d61a-40c0-b6c8-2fca7c38593d", 4000m, 400m, "Food and Drink" },
                    { "89f00d46-a1b7-4a9d-a20a-b397cdfc7f9b", 15000m, 10000m, "Education" },
                    { "a27a5821-030b-43f3-8f49-db23def4a950", 20000m, 1000m, "Research and Devolopment" },
                    { "ceb2c93d-8336-4ceb-b1a5-83ce2e2d372f", 1000m, 1m, "Others" },
                    { "db1a9bd5-fc1f-45cf-82f0-2e5105ffbdf0", 5000m, 1000m, "Travel" }
                });
        }
    }
}
