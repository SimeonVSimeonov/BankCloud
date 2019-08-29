using System.Collections.Generic;

namespace BankCloud.Models.ViewModels.Accounts
{
    public class AccountsDetailViewModel
    {

        public string Id { get; set; }

        public string IBAN { get; set; }

        public string CurrencyName { get; set; }

        public string IsoCode { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutcome { get; set; }

        public decimal Balance { get; set; }

        public IEnumerable<TransfersDetailViewModel> Transfers { get; set; }
    }
}
