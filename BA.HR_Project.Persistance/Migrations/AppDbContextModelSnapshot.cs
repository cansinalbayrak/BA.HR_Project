﻿// <auto-generated />
using System;
using BA.HR_Project.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BA.HR_Project.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Advance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AdvanceType")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ConfirmStatus")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Advances");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BirthPlace")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTurkishCitizen")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ab02e92d-d11e-467d-ae01-ae2f7621285d",
                            AccessFailedCount = 0,
                            Adress = "Ankara",
                            BirthDate = new DateTime(2024, 1, 11, 13, 6, 24, 582, DateTimeKind.Local).AddTicks(9572),
                            CompanyId = "SeedCompany1",
                            ConcurrencyStamp = "c9aa8baa-be9b-420d-9d3a-f690afa8639c",
                            DepartmentId = "SeedDepartment1",
                            Email = "admin.bilgeadam@bilgeadamboost.com",
                            EmailConfirmed = true,
                            IsTurkishCitizen = true,
                            LockoutEnabled = false,
                            Name = "Admin",
                            NormalizedEmail = "ADMIN.BILGEADAM@BILGEADAMBOOST.COM",
                            NormalizedUserName = "ADMIN.BILGEADAM@BILGEADAMBOOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGNQs00PI5DND1AZbUHk4Yzd/T2XbiAt/TGjSV8zsRYwS2UyLXCycQ7hg2hpI+V0ew==",
                            PhoneNumber = "0",
                            PhoneNumberConfirmed = false,
                            PhotoPath = "/mexant/assets/images/Default.jpg",
                            SecurityStamp = "35e8b9d9-b978-48e1-9367-6aeea5240993",
                            Surname = "Bilgeadam",
                            TwoFactorEnabled = false,
                            UserName = "admin.bilgeadam@bilgeadamboost.com"
                        });
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActivtyEnum")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyTitleEnum")
                        .HasColumnType("int");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MersisNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaxNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = "SeedCompany1",
                            ActivtyEnum = 1,
                            Adress = "Bilkent-Ankara",
                            CompanyTitleEnum = 1,
                            ContractEndDate = new DateTime(2024, 1, 11, 13, 6, 24, 584, DateTimeKind.Local).AddTicks(3528),
                            ContractStartDate = new DateTime(2024, 1, 11, 13, 6, 24, 584, DateTimeKind.Local).AddTicks(3527),
                            EmployeeCount = 0,
                            LogoPath = "/images/akademilogo-yatay.webp",
                            Mail = "info@bilgeadamboost.com",
                            MersisNo = "MersisNo",
                            Name = "BilgeAdam",
                            Phone = "1234567890",
                            StartUpDate = new DateTime(2024, 1, 11, 13, 6, 24, 584, DateTimeKind.Local).AddTicks(3525),
                            TaxNo = "TaxNo",
                            TaxOffice = "Bilken Vergi Dairesi"
                        });
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.DayOff", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ConfirmStatus")
                        .HasColumnType("int");

                    b.Property<float?>("DayCount")
                        .HasColumnType("real");

                    b.Property<int>("DayOffType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("DayOffs");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = "SeedDepartment1",
                            Name = "BoostAkademi"
                        });
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Expense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ConfirmStatus")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RequestPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ExpenseTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.ExpenseType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ExpenseMaxPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ExpenseMinPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            Id = "de30c0e1-398a-45b7-a3c0-f5049e0830d5",
                            ExpenseMaxPrice = 10000m,
                            ExpenseMinPrice = 1000m,
                            ExpenseName = "Marketing and Advertising Expenditures"
                        },
                        new
                        {
                            Id = "84dd2daa-b84b-4e11-895b-ea03b418d431",
                            ExpenseMaxPrice = 15000m,
                            ExpenseMinPrice = 1000m,
                            ExpenseName = "Accomodation"
                        },
                        new
                        {
                            Id = "d7978880-174e-4f4e-b77c-f8731f309a62",
                            ExpenseMaxPrice = 5000m,
                            ExpenseMinPrice = 1000m,
                            ExpenseName = "Travel"
                        },
                        new
                        {
                            Id = "3c6df95a-28b4-42e6-ad58-e1cae290fb42",
                            ExpenseMaxPrice = 4000m,
                            ExpenseMinPrice = 400m,
                            ExpenseName = "Food and Drink"
                        },
                        new
                        {
                            Id = "81b39fcb-3a44-4185-9307-5a649853935a",
                            ExpenseMaxPrice = 15000m,
                            ExpenseMinPrice = 10000m,
                            ExpenseName = "Education"
                        },
                        new
                        {
                            Id = "dbe70316-699d-4983-9afa-20fcb7679944",
                            ExpenseMaxPrice = 20000m,
                            ExpenseMinPrice = 1000m,
                            ExpenseName = "Research and Devolopment"
                        },
                        new
                        {
                            Id = "c073e4d1-70a3-4af7-8907-980554d30822",
                            ExpenseMaxPrice = 1000m,
                            ExpenseMinPrice = 1m,
                            ExpenseName = "Others"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Advance", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", "AppUser")
                        .WithMany("Advances")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.AppUser", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.Company", "Company")
                        .WithMany("AppUsers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BA.HR_Project.Domain.Entities.Department", "Department")
                        .WithMany("AppUsers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.DayOff", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", "AppUser")
                        .WithMany("DayOffs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Expense", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", "AppUser")
                        .WithMany("Expenses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BA.HR_Project.Domain.Entities.ExpenseType", "ExpenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BA.HR_Project.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("Advances");

                    b.Navigation("DayOffs");

                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Company", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.Department", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("BA.HR_Project.Domain.Entities.ExpenseType", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
