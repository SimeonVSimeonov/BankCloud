using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderSaves
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedOn { get; set; }

        public decimal CostPrice { get; set; }

        [Required]
        public string ContractorId { get; set; }
        public BankUser Contractor { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public string SaveId { get; set; }
        public Save Save { get; set; }
    }
}
