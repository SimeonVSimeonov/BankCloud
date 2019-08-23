using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountInputModel
    {
        [Required]
        public string IBAN { get; set; }

        //public decimal Charge { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal MonthlyIncome { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
