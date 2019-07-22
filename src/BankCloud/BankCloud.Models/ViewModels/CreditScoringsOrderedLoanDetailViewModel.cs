using System.Collections.Generic;

namespace BankCloud.Models.ViewModels
{
    public class CreditScoringsOrderedLoanDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Buyer { get; set; }

        public IEnumerable<UsersAccountViewModel> BuyerAcconts { get; set; }

        public string Status { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public string IssuedOn { get; set; }

        public string CompletedOn { get; set; }

        public decimal Commission { get; set; }

        public decimal MonthlyFee { get; set; }

        public string Curency { get; set; }

    }
}
