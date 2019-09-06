using BankCloud.Models.BindingModels.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Orders
{
    public class OrdersOrderLoanInputModel
    {
        private const string EnterPeriod = "Enter a Period ( in months count ) not more than";
        private const string EnterAmount = "Enter a Amount not more than";
        private const string AutoMonthlyFee = "Monthly Fee (it's auto calculate)";
        private const string SpecifyAccount = "Specify a money transfer account";

        private const string MonthlyFeeMinValue = "0.01";
        private const string MonthlyFeeMaxValue = "1000000000";

        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Range(LoanConstants.LoanPeriodMinValue, LoanConstants.LoanPeriodMaxValue)]
        [Display(Name = EnterPeriod)]
        public int Period { get; set; }

        [Required]
        [Range(typeof(decimal), LoanConstants.LoanAmountMinValue, LoanConstants.LoanAmountMaxValue)]
        [Display(Name = EnterAmount)]
        public decimal Amount { get; set; }

        [Display(Name = AutoMonthlyFee)]
        [Range(typeof(decimal), MonthlyFeeMinValue, MonthlyFeeMaxValue)]
        public decimal MonthlyFee { get; set; }

        [Required]
        [Range(typeof(decimal), LoanConstants.LoanCommissionMinValue, LoanConstants.LoanCommissionMaxValue)]
        public decimal Commission { get; set; }

        public string CurrencyName { get; set; }

        [Required]
        [Range(typeof(decimal), LoanConstants.LoanRateMinValue, LoanConstants.LoanRateMaxValue)]
        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = SpecifyAccount)]
        public string AccountId { get; set; }

        public ICollection<string> UserCurrencyTypes { get; set; }
    }
}
