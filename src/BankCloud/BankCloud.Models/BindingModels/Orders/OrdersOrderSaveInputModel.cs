using BankCloud.Models.BindingModels.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Orders
{
    public class OrdersOrderSaveInputModel
    {
        private const string OrderSaveAmountMinValue = "0.01";
        private const string OrderSaveAmountMaxValue = "1000000000";

        private const string OrderSaveIncomeMinValue = "0.01";
        private const string OrderSaveIncomeMaxValue = "1000000000";

        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Range(SaveConstants.SavePeriodMinValue, SaveConstants.SavePeriodMaxValue)]
        public int Period { get; set; }

        [Required]
        [Range(typeof(decimal), OrderSaveAmountMinValue, OrderSaveAmountMaxValue)]
        [Display(Name = BindingModelsConstants.EnterAmount)]
        public decimal Amount { get; set; }

        [Required]
        [Range(typeof(decimal), OrderSaveIncomeMinValue, OrderSaveIncomeMaxValue)]
        public decimal MonthlyIncome { get; set; }

        public string CurrencyName { get; set; }

        [Required]
        [Range(typeof(decimal), SaveConstants.SaveRateMinValue, SaveConstants.SaveRateMaxValue)]
        public decimal InterestRate { get; set; }

        [Required]
        [Display(Name = BindingModelsConstants.TransferAccount)]
        public string AccountId { get; set; }

        public ICollection<string> UserCurrencyTypes { get; set; }
    }
}
