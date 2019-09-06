using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountsChargeInputModel
    {

        private const int TransferDescriptionMinLength = 6;
        private const int TransferDescriptionMaxLength = 20;

        private const string AmountMinValue = "0.01";
        private const string AmountMaxValue = "1000000000";

        public string Id { get; set; }

        public string IsoCode { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.SpecifyAmount)]
        [Range(typeof(decimal), AmountMinValue, AmountMaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.TransferDescription)]
        [StringLength(TransferDescriptionMaxLength, MinimumLength = TransferDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime? Completed { get; set; }
    }
}
