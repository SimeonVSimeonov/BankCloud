using BankCloud.Models.BindingModels.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Products
{
    public class SellsLoanInputModel
    {
        public const string LoanPeriod = "Specify a maximum period ( in months count )";
        public const string LoanAmount = "Specify a maximum amount";
        public const string LoanCommission = "Specify a commission ( service fee in % )";

        public const int LoanNameMinLength = 6;
        public const int LoanNameMaxLength = 18;

        public const int LoanDescriptionMinLength = 600;
        public const int LoanDescriptionMaxLength = 1200;

        [Required]
        [StringLength(LoanNameMaxLength, MinimumLength = LoanNameMinLength)]
        [Display(Name = BindingModelsConstants.ProductName)]
        public string Name { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.ProductAdPicture)]
        public IFormFile AdUrl { get; set; }

        [Required]
        [StringLength(LoanDescriptionMaxLength, MinimumLength = LoanDescriptionMinLength)]
        [Display(Name = BindingModelsConstants.ProductDescription)]
        public string Description { get; set; }

        [Display(Name = BindingModelsConstants.InterestRate)]
        [Range(typeof(decimal), LoanConstants.LoanRateMinValue, LoanConstants.LoanRateMaxValue)]
        public decimal InterestRate { get; set; }

        [Display(Name = LoanPeriod)]
        [Range(LoanConstants.LoanPeriodMinValue, LoanConstants.LoanPeriodMaxValue)]
        public int Period { get; set; }

        [Display(Name = LoanAmount)]
        [Range(typeof(decimal), LoanConstants.LoanAmountMinValue, LoanConstants.LoanAmountMaxValue)]
        public decimal Amount { get; set; }

        [Range(typeof(decimal), LoanConstants.LoanCommissionMinValue, LoanConstants.LoanCommissionMaxValue)]
        [Display(Name = LoanCommission)]
        public decimal Commission { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.TransferAccount)]
        public string AccountId { get; set; }
    }
}
