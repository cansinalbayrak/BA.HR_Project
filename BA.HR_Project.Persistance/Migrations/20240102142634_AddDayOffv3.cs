using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class AddDayOffv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_AspNetUsers_AppUserId",
                table: "DayOff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57c0c259-dcda-4ac1-9f83-7b53cbda4f95");

            migrationBuilder.RenameTable(
                name: "DayOff",
                newName: "DayOffs");

            migrationBuilder.RenameIndex(
                name: "IX_DayOff_AppUserId",
                table: "DayOffs",
                newName: "IX_DayOffs_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayOffs",
                table: "DayOffs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7345270-d778-4904-afa4-010c770d5936", 0, "Ankara", new DateTime(2024, 1, 2, 17, 26, 33, 792, DateTimeKind.Local).AddTicks(2841), null, "SeedCompany1", "40d2aba3-fd61-494e-bef7-5c3f804a3ecb", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEDdqSc7wzJyTdff941uIiNjy0s8AZvprpNXL8kB4c7tICOxcqSiiZps7DdN3vb3/kQ==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "a93258eb-783c-4ff5-90a5-90a431b0a063", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffs_AspNetUsers_AppUserId",
                table: "DayOffs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffs_AspNetUsers_AppUserId",
                table: "DayOffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayOffs",
                table: "DayOffs");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7345270-d778-4904-afa4-010c770d5936");

            migrationBuilder.RenameTable(
                name: "DayOffs",
                newName: "DayOff");

            migrationBuilder.RenameIndex(
                name: "IX_DayOffs_AppUserId",
                table: "DayOff",
                newName: "IX_DayOff_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "57c0c259-dcda-4ac1-9f83-7b53cbda4f95", 0, "Ankara", new DateTime(2024, 1, 2, 17, 7, 11, 573, DateTimeKind.Local).AddTicks(2003), null, "SeedCompany1", "34e803b1-f725-43e7-a7d7-8563272fe279", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAELeaXtih3jF5uClGomsNLmf6Ai0SSTyw5NNDgEe+ZB9qMK7QXlTIK1DWyR6qm86ibg==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "3f6b5e91-e4ab-4e26-877d-5d85d78e2ddf", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_AspNetUsers_AppUserId",
                table: "DayOff",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
