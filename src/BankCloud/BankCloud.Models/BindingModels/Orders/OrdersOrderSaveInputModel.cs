using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Orders
{
    public class OrdersOrderSaveInputModel
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Period { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Display(Name = "Enter a Desired Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal MonthlyIncome { get; set; }

        public string CurrencyName { get; set; }

        public ICollection<string> UserCurrencyTypes { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = "Specify a money transfer account")]
        public string AccountId { get; set; }
    }
}
