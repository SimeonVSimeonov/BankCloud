using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountInputModel
    {

        public string IBAN { get; set; }

        [Required]
        [Display(Name = "Specify a avatar picture for your account")]
        public IFormFile AdUrl { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [Display(Name = "If you want declare your salary")]
        public decimal MonthlyIncome { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
