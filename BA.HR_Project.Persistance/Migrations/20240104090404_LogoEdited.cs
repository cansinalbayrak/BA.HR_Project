using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class LogoEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7791e0b1-d720-46c9-a2ed-f4e2ec85770c", 0, "Ankara", new DateTime(2024, 1, 4, 12, 4, 4, 567, DateTimeKind.Local).AddTicks(613), null, "SeedCompany1", "370a5269-bf77-4a16-8d8b-54bcfcf36acd", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEOHo7TYj+0z+PHc2wV78YyeAzArXuISNBodSSUen/uc7Ki5QonRTBPNDEVVtktypxg==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "9110e39d-6768-4440-8b8f-f2a983f84a62", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "SeedCompany1",
                column: "LogoPath",
                value: "/images/akademilogo-yatay.webp");

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "ExpenseId", "ExpenseMaxPrice", "ExpenseMinPrice", "ExpenseName" },
                values: new object[,]
                {
                    { "01dbce41-a2a0-4908-8567-3d0c6759bffc", null, 4000m, 400m, "Food and Drink" },
                    { "2961b4cd-428a-4f59-9b04-418d4c9c8f51", null, 10000m, 1000m, "Marketing and Advertising Expenditures" },
                    { "472747c6-7188-4407-8af0-cf85febfa7c8", null, 15000m, 1000m, "Accomodation" },
                    { "83824ce5-3697-4909-86ec-1f9d2d269e9c", null, 15000m, 10000m, "Education" },
                    { "99fe3fc5-5786-466a-bfe0-b826d94be4d8", null, 5000m, 1000m, "Travel" },
                    { "c1f98b23-b007-491f-8462-d3d7fab9bb1e", null, 1000m, 1m, "Others" },
                    { "e92a46d8-352f-40ff-8e0a-1241b7f3810f", null, 20000m, 1000m, "Research and Devolopment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7791e0b1-d720-46c9-a2ed-f4e2ec85770c");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "01dbce41-a2a0-4908-8567-3d0c6759bffc");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "2961b4cd-428a-4f59-9b04-418d4c9c8f51");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "472747c6-7188-4407-8af0-cf85febfa7c8");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "83824ce5-3697-4909-86ec-1f9d2d269e9c");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "99fe3fc5-5786-466a-bfe0-b826d94be4d8");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "c1f98b23-b007-491f-8462-d3d7fab9bb1e");

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: "e92a46d8-352f-40ff-8e0a-1241b7f3810f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41555a81-224c-4a38-954c-200f913d3851", 0, "Ankara", new DateTime(2024, 1, 3, 12, 10, 29, 320, DateTimeKind.Local).AddTicks(5856), null, "SeedCompany1", "1af8bdd7-b811-4d95-a582-ec74cc17b8c5", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAED5IeYVT77k4gkWN9t21zE0oei5vQEiiklXKtVjNVI1TVyyT04mqMbucN1Uh66yrTA==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "f515d9d3-b740-4239-84c9-112df4a05db4", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "SeedCompany1",
                column: "LogoPath",
                value: "BilgeAdamınLogosunuEkle");

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
        }
    }
}
