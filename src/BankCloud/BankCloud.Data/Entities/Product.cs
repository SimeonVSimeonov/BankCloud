using System;

namespace BankCloud.Data.Entities
{
    public abstract class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AdUrl { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public string Description { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal Commission { get; set; }

        public int Popularity { get; set; }

        public bool IsDeleted { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
