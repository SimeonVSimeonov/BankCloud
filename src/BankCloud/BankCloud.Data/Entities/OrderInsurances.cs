using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderInsurances
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedOn { get; set; }

        public decimal CostPrice { get; set; }

        [Required]
        public string BuyerId { get; set; }
        public BankUser Buyer { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public string InsuranceId { get; set; }
        public Insurance Insurance { get; set; }

    }
}
