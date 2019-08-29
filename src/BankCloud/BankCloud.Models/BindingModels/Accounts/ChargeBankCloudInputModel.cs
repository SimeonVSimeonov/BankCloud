using BankCloud.Data.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class ChargeBankCloudInputModel
    {
        public string Id { get; set; }

        public string IsoCode { get; set; }

        [Required]
        [StringLength(23, MinimumLength = 23)]
        [Display(Name = "Specify a BankCloud IBAN")]
        [RegularExpression("CLD [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}", ErrorMessage = "Please enter a valid BankCloud IBAN number!!!")]
        public string IBAN { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100,MinimumLength =10)]
        public string Description { get; set; }

        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
