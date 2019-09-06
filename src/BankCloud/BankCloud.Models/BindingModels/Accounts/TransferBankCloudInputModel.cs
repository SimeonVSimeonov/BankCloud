using BankCloud.Models.BindingModels.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class TransferBankCloudInputModel
    {
        private const string IBANRegExValidation = "CLD [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}";

        private const string AmountMinValue = "0.01";
        private const string AmountMaxValue = "1000000000";

        private const int TransferDescriptionMinLength = 6;
        private const int TransferDescriptionMaxLength = 20;

        private const int IBANMinLength = 23;
        private const int IBANMaxLength = 23;

        public string Id { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.SpecifyAmount)]
        [Range(typeof(decimal), AmountMinValue, AmountMaxValue)]
        public decimal Amount { get; set; }

        public decimal ConvertedAmount { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.TransferDescription)]
        [StringLength(TransferDescriptionMaxLength, MinimumLength = TransferDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(IBANMaxLength, MinimumLength = IBANMinLength)]
        [Display(Name = BindingModelsConstants.SpecifyIban)]
        [RegularExpression(IBANRegExValidation, ErrorMessage = BindingModelsConstants.ValidIbanNumber)]
        public string IBAN { get; set; }

        public string IsoCode { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
