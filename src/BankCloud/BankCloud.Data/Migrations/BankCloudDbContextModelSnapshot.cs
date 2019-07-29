﻿// <auto-generated />
using System;
using BankCloud.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankCloud.Data.Migrations
{
    [DbContext(typeof(BankCloudDbContext))]
    partial class BankCloudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("CurrencyId");

                    b.Property<string>("IBAN");

                    b.Property<decimal>("MonthlyIncome");

                    b.Property<decimal>("MonthlyOutcome");

                    b.HasKey("Id");

                    b.HasIndex("BankUserId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Accounts");
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

                    b.Property<bool>("IsActive");

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

                    b.Property<string>("BuyerId")
                        .IsRequired();

                    b.Property<decimal>("CostPrice");

                    b.Property<DateTime?>("IssuedOn");

                    b.Property<int>("Level");

                    b.Property<DateTime?>("UntilTo");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("CreditScorings");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Currency", b =>
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

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<string>("BankUserId");

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<decimal>("CostPrice");

                    b.Property<decimal>("InterestRate");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<decimal>("MonthlyFee");

                    b.Property<string>("Name");

                    b.Property<string>("OrderType")
                        .IsRequired();

                    b.Property<int>("Period");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BankUserId");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("OrderType").HasValue("Order");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<string>("AdUrl");

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("Commission");

                    b.Property<decimal>("InterestRate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("Period");

                    b.Property<string>("ProductType")
                        .IsRequired();

                    b.Property<string>("SellerID");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SellerID");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("ProductType").HasValue("Product");
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

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInsurance", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Order");

                    b.Property<string>("InsuranceId");

                    b.HasIndex("InsuranceId");

                    b.HasDiscriminator().HasValue("orderinsurance");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInvestment", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Order");

                    b.Property<string>("InvestmentId");

                    b.HasIndex("InvestmentId");

                    b.HasDiscriminator().HasValue("orderinvestment");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderLoan", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Order");

                    b.Property<string>("LoanId");

                    b.HasIndex("LoanId");

                    b.HasDiscriminator().HasValue("orderloan");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderSave", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Order");

                    b.Property<string>("SaveId");

                    b.HasIndex("SaveId");

                    b.HasDiscriminator().HasValue("ordersave");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Insurance", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Product");

                    b.Property<decimal>("Installment");

                    b.Property<int>("Type");

                    b.HasDiscriminator().HasValue("insurance");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Investment", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Product");

                    b.HasDiscriminator().HasValue("investment");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Loan", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Product");

                    b.HasDiscriminator().HasValue("loan");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Save", b =>
                {
                    b.HasBaseType("BankCloud.Data.Entities.Product");

                    b.HasDiscriminator().HasValue("save");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Account", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser", "BankUser")
                        .WithMany("Accounts")
                        .HasForeignKey("BankUserId");

                    b.HasOne("BankCloud.Data.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.BankUser", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.CreditScoring", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.BankUser", "Buyer")
                        .WithMany("CreditScorings")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Order", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("BankCloud.Data.Entities.BankUser")
                        .WithMany("Orders")
                        .HasForeignKey("BankUserId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.Product", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("BankCloud.Data.Entities.BankUser", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerID");
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

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInsurance", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderInvestment", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Investment", "Investment")
                        .WithMany()
                        .HasForeignKey("InvestmentId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderLoan", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("BankCloud.Data.Entities.OrderSave", b =>
                {
                    b.HasOne("BankCloud.Data.Entities.Save", "Save")
                        .WithMany()
                        .HasForeignKey("SaveId");
                });
#pragma warning restore 612, 618
        }
    }
}
