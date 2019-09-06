using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountInputModel
    {
        private const string AccountAvatar = "Specify a avatar picture for your account";
        private const string DeclareSalary = "If you want declare your salary";

        private const string MonthlyIncomeMinValue = "0.00";
        private const string MonthlyIncomeMaxValue = "1000000000";

        private const string BalanceMinValue = "0.00";
        private const string BalanceMaxValue = "1000000000";

        public string IBAN { get; set; }

        [Required]
        [Display(Name = AccountAvatar)]
        public IFormFile AdUrl { get; set; }

        [Range(typeof(decimal), MonthlyIncomeMinValue, MonthlyIncomeMaxValue)]
        [Display(Name = DeclareSalary)]
        public decimal MonthlyIncome { get; set; }

        [Range(typeof(decimal), BalanceMinValue, BalanceMaxValue)]
        public decimal Balance { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
