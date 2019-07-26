using System;
using System.Collections.Generic;
using System.Text;
using BankCloud.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Data.Context
{
    public class BankCloudDbContext : IdentityDbContext<BankUser, BankUserRole, string>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditScoring> CreditScorings { get; set; }
        public DbSet<Curency> Curencies { get; set; }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<OrderLoan> OrderLoans { get; set; }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<OrderInsurances> OrderInsurances { get; set; }

        public DbSet<Save> Saves { get; set; }
        public DbSet<OrderSaves> OrderSaves { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderPayments> OrderPayments { get; set; }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<OrderInvestments> OrderInvestments { get; set; }

        public BankCloudDbContext(DbContextOptions<BankCloudDbContext> options)
            : base(options)
        {
        }

        public BankCloudDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-KDM5RU8\\SQLEXPRESS;Database=BankCloud;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<CreditScoring>()
            //    .HasOne(credit => credit.Order)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderLoan>()
                .HasOne(ol => ol.Loan)
                .WithMany()
                .HasForeignKey(x => x.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Loan>()
                .HasOne(a => a.Account)
                .WithMany(a => a.Loans)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Account>()
                .HasMany(x => x.Loans)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Account>()
            //    .HasMany(x => x.Loans)
            //    .WithOne(x => x.Account)
            //    .HasForeignKey(x => x.)

            builder.Entity<CreditScoring>()
                .HasOne(credit => credit.Buyer)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BankUser>()
               .HasKey(user => user.Id);

            builder.Entity<BankUser>()
                .HasMany(user => user.CreditScorings)
                .WithOne(credit => credit.Buyer)
                .HasForeignKey(credit => credit.BuyerId);

            //builder.Entity<BankUser>()
            //    .HasMany(user => user.Orders)
            //    .WithOne(order => order.Contractor)
            //    .HasForeignKey(order => order.ContractorId);

            base.OnModelCreating(builder);
        }
    }
}
