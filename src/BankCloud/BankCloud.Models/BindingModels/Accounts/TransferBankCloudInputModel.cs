using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class TransferBankCloudInputModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Specify amount")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        public decimal? ConvertedAmount { get; set; }

        [Required]
        [Display(Name = "Specify description for transfer")]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(23, MinimumLength = 23)]
        [Display(Name = "Specify a IBAN")]
        [RegularExpression("CLD [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}", ErrorMessage = "Please enter a valid IBAN number!!!")]
        public string IBAN { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
