using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class ChargeBankCloudInputModel
    {
        private const string BankCloudIBAN = "Specify a BankCloud IBAN";
        private const string BankCloudIBANErrorMessage = "Please enter a valid BankCloud IBAN number!!!";
        private const string BankCloudIBANRegExValidation = "CLD [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}";

        private const int BankCloudIBANMinLength = 23;
        private const int BankCloudIBANMaxLength = 23;

        private const string AmountMinValue = "0.01";
        private const string AmountMaxValue = "1000000000";

        private const int TransferDescriptionMinLength = 6;
        private const int TransferDescriptionMaxLength = 20;

        public string Id { get; set; }

        public string IsoCode { get; set; }

        [Required]
        [StringLength(BankCloudIBANMaxLength, MinimumLength = BankCloudIBANMinLength)]
        [Display(Name = BankCloudIBAN)]
        [RegularExpression(BankCloudIBANRegExValidation, ErrorMessage = BankCloudIBANErrorMessage)]
        public string IBAN { get; set; }

        [Required]
        [Range(typeof(decimal), AmountMinValue, AmountMaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(TransferDescriptionMaxLength, MinimumLength = TransferDescriptionMinLength)]
        public string Description { get; set; }

        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
