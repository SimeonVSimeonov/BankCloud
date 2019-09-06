using BankCloud.Models.BindingModels.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Products
{
    public class SellsSaveInputModel
    {
        public const string SavePeriod = "Specify a Deposit Period (if Open specify 0 )";
        public const string SavePenalty = "Specify a penalty ( fee in % if Open specify 0 )";

        public const int SaveNameMinLength = 6;
        public const int SaveNameMaxLength = 18;

        public const int SaveDescriptionMinLength = 600;
        public const int SaveDescriptionMaxLength = 1200;

        [StringLength(SaveNameMaxLength, MinimumLength = SaveNameMinLength)]
        [Display(Name = BindingModelsConstants.ProductName)]
        public string Name { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.ProductAdPicture)]
        public IFormFile AdUrl { get; set; }

        [StringLength(SaveDescriptionMaxLength, MinimumLength = SaveDescriptionMinLength)]
        [Display(Name = BindingModelsConstants.ProductDescription)]
        public string Description { get; set; }

        [Display(Name = BindingModelsConstants.InterestRate)]
        [Range(typeof(decimal), SaveConstants.SaveRateMinValue, SaveConstants.SaveRateMaxValue)]
        public decimal InterestRate { get; set; }

        [Display(Name = SavePeriod)]
        [Range(SaveConstants.SavePeriodMinValue, SaveConstants.SavePeriodMaxValue)]
        public int Period { get; set; }

        [Range(typeof(decimal), SaveConstants.SavePenaltyRateMinValue, SaveConstants.SavePenaltyRateMaxValue)]
        [Display(Name = SavePenalty)]
        public decimal PenaltyInterest { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.TransferAccount)]
        public string AccountId { get; set; }
    }
}
