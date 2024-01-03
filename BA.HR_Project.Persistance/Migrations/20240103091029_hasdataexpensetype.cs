using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class hasdataexpensetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d48c72c-c73e-4caf-a7f7-158b31cf84db");

            migrationBuilder.DropColumn(
                name: "MainPrice",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "MaxFactor",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "MinFactor",
                table: "ExpenseTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpenseMinPrice",
                table: "ExpenseTypes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpenseMaxPrice",
                table: "ExpenseTypes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseId",
                table: "ExpenseTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41555a81-224c-4a38-954c-200f913d3851", 0, "Ankara", new DateTime(2024, 1, 3, 12, 10, 29, 320, DateTimeKind.Local).AddTicks(5856), null, "SeedCompany1", "1af8bdd7-b811-4d95-a582-ec74cc17b8c5", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAED5IeYVT77k4gkWN9t21zE0oei5vQEiiklXKtVjNVI1TVyyT04mqMbucN1Uh66yrTA==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "f515d9d3-b740-4239-84c9-112df4a05db4", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseId", "ExpenseMaxPrice", "ExpenseMinPrice", "ExpenseName" },
                values: new object[,]
                {
                    { "0d6f889b-0afa-451d-aeee-ed5587203b17", null, 15000m, 10000m, "Education" },
                    { "0eb7ef9c-61de-4800-918a-3cb216d9d702", null, 10000m, 1000m, "Marketing and Advertising Expenditures" },
                    { "1adbd1bb-b8f8-4966-b0a2-64ca8b5e2799", null, 4000m, 400m, "Food and Drink" },
                    { "21f01d92-3918-443d-8f6a-97c7a79d26eb", null, 5000m, 1000m, "Travel" },
                    { "21f477b1-c151-4e17-95df-2fe900834926", null, 1000m, 1m, "Others" },
                    { "6409c2f3-9866-4098-a6a6-522513540e22", null, 20000m, 1000m, "Research and Devolopment" },
                    { "894ab81e-a585-413d-b127-8e02decf1893", null, 15000m, 1000m, "Accomodation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId",
                unique: true,
                filter: "[ExpenseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41555a81-224c-4a38-954c-200f913d3851");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "0d6f889b-0afa-451d-aeee-ed5587203b17");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "0eb7ef9c-61de-4800-918a-3cb216d9d702");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "1adbd1bb-b8f8-4966-b0a2-64ca8b5e2799");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "21f01d92-3918-443d-8f6a-97c7a79d26eb");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "21f477b1-c151-4e17-95df-2fe900834926");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "6409c2f3-9866-4098-a6a6-522513540e22");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "894ab81e-a585-413d-b127-8e02decf1893");

            migrationBuilder.AlterColumn<float>(
                name: "ExpenseMinPrice",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "ExpenseMaxPrice",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseId",
                table: "ExpenseTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MainPrice",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaxFactor",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinFactor",
                table: "ExpenseTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d48c72c-c73e-4caf-a7f7-158b31cf84db", 0, "Ankara", new DateTime(2024, 1, 3, 1, 35, 0, 465, DateTimeKind.Local).AddTicks(3910), null, "SeedCompany1", "8a495d66-4837-4730-8a55-03c665a2fd6c", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEGQg60bOyUbgUWIKqT2fJ62WMK7X8anNgH5KSp3oLJmnQAjAynxGNJP+bkYCrGBynw==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "e896a24a-f34b-4b56-bcb9-723178872f29", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
