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
        //public DbSet<BankUser> BankUsers { get; set; }
        //public DbSet<BankUserRole> BankUserRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditScoring> CreditScorings { get; set; }
        public DbSet<Curency> Curencies { get; set; }
        public DbSet<FullName> FullNames { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

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
            //builder.Entity<CreditScoring>().HasKey(x => new { x.ContractorId, x.OrderId });

            builder.Entity<CreditScoring>()
                .HasOne(credit => credit.Order)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CreditScoring>()
                .HasOne(credit => credit.Contractor)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BankUser>()
               .HasKey(user => user.Id);

            builder.Entity<BankUser>()
                .HasMany(user => user.CreditScorings)
                .WithOne(credit => credit.Contractor)
                .HasForeignKey(credit => credit.ContractorId);

            builder.Entity<BankUser>()
                .HasMany(user => user.Orders)
                .WithOne(order => order.Contractor)
                .HasForeignKey(order => order.ContractorId);

            base.OnModelCreating(builder);

            //builder.Entity<BankUser>().HasKey(x => x.Id);
        }
    }
}
