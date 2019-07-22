using BankCloud.Data.Entities.Enums;

namespace BankCloud.Data.Entities
{
    public class Account
    {
        public string Id { get; set; }

        public string IBAN { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutcome { get; set; }

        public decimal Balance { get; set; }

        public string BankUserId { get; set; }
        public BankUser BankUser { get; set; }

        public string CurencyId { get; set; }
        public Curency Curency { get; set; }
    }
}
