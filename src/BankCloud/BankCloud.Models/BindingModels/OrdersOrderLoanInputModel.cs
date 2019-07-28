using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class OrdersOrderLoanInputModel
    {
        [Required]
        public string Id { get; set; }

        //[Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Enter a Period ( in months count ) not more than")]
        public int Period { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Display(Name = "Enter a Amount not more than")]
        public decimal Amount { get; set; }

        [Display(Name = "Monthly Fee (it's auto calculate)")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MonthlyFee { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Commission { get; set; }

        //[Required]
        public string CurrencyName { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = "Specify a money transfer account")]
        public string AccountId { get; set; }
    }
}
