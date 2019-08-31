using BankCloud.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Data.Context
{
    public class BankCloudDbContext : IdentityDbContext<BankUser, BankUserRole, string>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transfer> Transfers { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditScoring> CreditScorings { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderLoan> OrdersLoans { get; set; }
        public DbSet<OrderSave> OrdersSaves { get; set; }
        public DbSet<OrderInsurance> OrdersInsurances { get; set; }
        public DbSet<OrderInvestment> OrdersInvestments { get; set; }

        public BankCloudDbContext(DbContextOptions<BankCloudDbContext> options)
            : base(options)
        {
        }

        public BankCloudDbContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //            .UseSqlServer("Data Source=tcp:bankcloud.database.windows.net,1433;Initial Catalog=BankCloudSqlServer;User Id=bankcloudadmin@bankcloud.database.windows.net;Password=Ger100100@;");
        //    }

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasMany(x => x.Transfers)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Product>().ToTable("Products");

            builder.Entity<Product>()
                    .ToTable("Products")
                    .HasDiscriminator<string>("ProductType")
                    .HasValue<Loan>("loan")
                    .HasValue<Save>("save")
                    .HasValue<Insurance>("insurance")
                    .HasValue<Investment>("investment");

            base.OnModelCreating(builder);
        }
    }
}
