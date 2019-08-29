using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountsChargeInputModel
    {
        public string Id { get; set; }

        public string IsoCode { get; set; }

        [Required]
        [Display(Name = "Specify amount")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Specify description for transfer")]
        [StringLength(20, MinimumLength = 6)]
        public string Description { get; set; }

        [Required]
        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
