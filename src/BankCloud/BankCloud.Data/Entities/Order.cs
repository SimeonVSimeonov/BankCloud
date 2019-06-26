using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime? CompletedOn { get; set; }

        public decimal CostPrice { get; set; }

        [Required]
        public string ContractorId { get; set; }
        public BankUser Contractor { get; set; }

        [Required]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

    }
}