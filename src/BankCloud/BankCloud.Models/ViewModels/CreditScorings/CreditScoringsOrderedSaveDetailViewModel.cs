using BankCloud.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels.CreditScorings
{
    public class CreditScoringsOrderedSaveDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Buyer { get; set; }

        public string AccountForTransfer { get; set; }

        public IEnumerable<UsersAccountViewModel> BuyerAcconts { get; set; }

        public string Status { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public string IssuedOn { get; set; }

        public string CompletedOn { get; set; }

        public decimal Commission { get; set; }

        public decimal MonthlyFee { get; set; }

        public string CurrencyIso { get; set; }

        public string CurrencyName { get; set; }
    }
}
