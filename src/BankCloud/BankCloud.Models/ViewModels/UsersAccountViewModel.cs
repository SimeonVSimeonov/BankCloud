namespace BankCloud.Models.ViewModels
{
    public class UsersAccountViewModel
    {
        public string IBAN { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutCome { get; set; }

        public decimal Balance { get; set; }

        public string CurencyIso { get; set; }

        public string CurencyName { get; set; }

    }
}
