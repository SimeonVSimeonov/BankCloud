using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Data.Entities
{
    public abstract class Order
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedOn { get; set; }

        public decimal CostPrice { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public int Period { get; set; }

        //[Required]
        //public string BuyerId { get; set; }
        //public BankUser Buyer { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
