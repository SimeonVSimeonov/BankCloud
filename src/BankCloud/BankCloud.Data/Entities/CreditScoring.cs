using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class CreditScoring
    {
        public string Id { get; set; }

        [Required]
        public ScoringLevel Level { get; set; }

        public DateTime? IssuedOn { get; set; }

        public DateTime? UntilTo { get; set; }

        public decimal CostPrice { get; set; }

        [Required]
        public string BuyerId { get; set; }
        public BankUser Buyer { get; set; }

    }
}