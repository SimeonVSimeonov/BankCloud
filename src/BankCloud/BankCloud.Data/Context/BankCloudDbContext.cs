using BankCloud.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Data.Context
{
    public class BankCloudDbContext : IdentityDbContext<BankUser, BankUserRole, string>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditScoring> CreditScorings { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

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

            builder.Entity<Product>().ToTable("Products");

            builder.Entity<Product>()
                    .ToTable("Products")
                    .HasDiscriminator<string>("ProductType")
                    .HasValue<Loan>("loan")
                    .HasValue<Save>("save")
                    .HasValue<Insurance>("insurance")
                    .HasValue<Investment>("investment");

            builder.Entity<Order>().ToTable("Orders");

            builder.Entity<Order>()
                    .ToTable("Orders")
                    .HasDiscriminator<string>("OrderType")
                    .HasValue<OrderLoan>("orderloan")
                    .HasValue<OrderSave>("ordersave")
                    .HasValue<OrderInsurance>("orderinsurance")
                    .HasValue<OrderInvestment>("orderinvestment");

            base.OnModelCreating(builder);
        }
    }
}
