using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class SellsLoanInputModel
    {
        [StringLength(18, MinimumLength = 6)]
        [Display(Name = "Specify a name for your product")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Specify a advertising picture for your product")]
        public IFormFile AdUrl { get; set; }

        [StringLength(1200, MinimumLength = 600)]
        [Display(Name = "Specify a description and additional conditions")]
        public string Description { get; set; }

        [Display(Name = "Specify a interest rate ( in % )")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InterestRate { get; set; }

        [Display(Name = "Specify a maximum period ( in months count )")]
        [Range(1, int.MaxValue)]
        public int Period { get; set; }

        [Display(Name = "Specify a maximum amount")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [Display(Name = "Specify a commission ( service fee in % )")]
        public decimal Commission { get; set; }

        [Required]
        [Display(Name = "Specify a money transfer account")]
        public string AccountId { get; set; }
    }
}
