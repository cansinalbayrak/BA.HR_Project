using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    public partial class AddDayOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7539dc6b-686a-41ba-8561-d78e63d6269e");

            migrationBuilder.CreateTable(
                name: "DayOff",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayCount = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmStatus = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOffType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOff_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "abbcc463-11c1-4e99-aee9-f403a307f6d3", 0, "Ankara", new DateTime(2024, 1, 2, 16, 32, 59, 307, DateTimeKind.Local).AddTicks(2927), null, "SeedCompany1", "dc5e644d-954d-4785-a323-ae658bebcd12", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEHqhZIi0Zv/VJybotPW2L0R1u8WAqKk74KfYdBR0xJvUQ3L5m+GsmauyjsyQePm99g==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "2aa9c3a2-d2eb-4d34-8d37-573066b8d037", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_AppUserId",
                table: "DayOff",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abbcc463-11c1-4e99-aee9-f403a307f6d3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "EndDate", "IdentityNumber", "IsTurkishCitizen", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PassportNumber", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7539dc6b-686a-41ba-8561-d78e63d6269e", 0, "Ankara", new DateTime(2024, 1, 2, 14, 59, 41, 15, DateTimeKind.Local).AddTicks(2071), null, "SeedCompany1", "6db8d165-a863-4ad8-8837-d6234c7b4767", "SeedDepartment1", "admin.bilgeadam@bilgeadamboost.com", true, null, null, true, false, null, "Admin", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", "ADMIN.BILGEADAM@BILGEADAMBOOST.COM", null, "AQAAAAEAACcQAAAAEAygbmbuKuzP9MqG4nZQLvJWG40r7TFXIfW6Rf4jHSzj/tzPqJZawFX6gs/hlOosiA==", "0", false, "/mexant/assets/images/Default.jpg", null, null, null, "758dfd50-c3bc-4d70-8493-9d52effef133", null, "Bilgeadam", false, "admin.bilgeadam@bilgeadamboost.com" });
        }
    }
}
