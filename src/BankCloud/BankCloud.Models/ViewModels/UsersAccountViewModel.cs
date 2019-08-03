namespace BankCloud.Models.ViewModels
{
    public class UsersAccountViewModel
    {
        public string Id { get; set; }

        public string IBAN { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutCome { get; set; }

        public decimal Balance { get; set; }

        public string IsoCode { get; set; }

        public string CurrencyName { get; set; }

    }
}
