﻿// <auto-generated />
using System;
using BankCloud.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankCloud.Data.Migrations
{
    [DbContext(typeof(BankCloudDbContext))]
    [Migration("20190714142534_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankCloud.Data.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("BankUserId");

                    b.Property<string>("CurencyId");

                    b.Property<decimal>("MonthlyIncome");

                    b.HasKey("Id");

                    b.HasIndex("BankUserId");

                    b.HasIndex("CurencyId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.BankUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AddressId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("IdentityNumber");

                    b.Property<bool>("IsAgent");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Middlename");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.BankUserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.CreditScoring", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContractorId")
                        .IsRequired();

                    b.Property<decimal>("CostPrice");

                    b.Property<DateTime?>("IssuedOn");

                    b.Property<int>("Level");

                    b.Property<DateTime?>("UntilTo");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("CreditScorings");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Curency", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IsoCode")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<int>("ТrustLevel");

                    b.HasKey("Id");

                    b.ToTable("Curencies");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Insurance", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Coverage");

                    b.Property<string>("CurencyId");

                    b.Property<decimal>("Installment");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CurencyId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Investment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Loan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("Commission");

                    b.Property<string>("CurencyId");

                    b.Property<decimal>("InterestRate");

                    b.Property<string>("Name");

                    b.Property<int>("Period");

                    b.Property<string>("SellerID");

                    b.HasKey("Id");

                    b.HasIndex("CurencyId");

                    b.HasIndex("SellerID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInsurances", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<string>("ContractorId")
                        .IsRequired();

                    b.Property<decimal>("CostPrice");

                    b.Property<string>("InsuranceId");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("InsuranceId");

                    b.ToTable("OrderInsurances");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderLoans", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<string>("ContractorId")
                        .IsRequired();

                    b.Property<decimal>("CostPrice");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<string>("LoanId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("LoanId");

                    b.ToTable("OrderLoans");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Save", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Saves");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Account", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany("Accounts")
                        .HasForeignKey("BankUserId");

                    b.HasOne("BankCloud.Data.Entities.Curency", "Curency")
                        .WithMany()
                        .HasForeignKey("CurencyId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.BankUser", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.CreditScoring", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser", "Contractor")
                        .WithMany("CreditScorings")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Insurance", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Curency", "Curency")
                        .WithMany()
                        .HasForeignKey("CurencyId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Loan", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Curency", "Curency")
                        .WithMany()
                        .HasForeignKey("CurencyId");

                    b.HasOne("BankCloud.Data.Entities.BankUser", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerID");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInsurances", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser", "Contractor")
                        .WithMany("OrderInsurances")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankCloud.Data.Entities.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderLoans", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser", "Contractor")
                        .WithMany("OrderLoans")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankCloud.Data.Entities.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
