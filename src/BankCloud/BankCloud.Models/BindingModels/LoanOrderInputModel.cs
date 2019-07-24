using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class LoanOrderInputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Period { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Monthly Fee")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MonthlyFee { get; set; }

        [Required]
        public decimal Commission { get; set; }

        public string CurencyName { get; set; }

        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = "Specify a money transfer account")]
        public string AccountId { get; set; }
    }
}
