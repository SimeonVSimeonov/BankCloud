namespace BankCloud.Models.ViewModels.Users
{
    public class UsersAccountViewModel
    {
        public string Id { get; set; }

        public string AdUrl { get; set; }

        public string IBAN { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutCome { get; set; }

        public decimal Balance { get; set; }

        public int PendingRecharges { get; set; }

        public int PendingPayments { get; set; }

        public string IsoCode { get; set; }

        public string CurrencyName { get; set; }

    }
}
