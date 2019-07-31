using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class SellsLoanInputModel
    {
        [StringLength(18, MinimumLength = 6)]
        [Display(Name = "Specify a name for your product")]
        public string Name { get; set; }

        [Display(Name = "Specify a Interest Rate ( in % )")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InterestRate { get; set; }

        [Display(Name = "Specify a Maximum Period ( in months count )")]
        [Range(1, int.MaxValue)]
        public int Period { get; set; }

        [Display(Name = "Specify a Maximum Amount")]
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
