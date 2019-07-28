using BankCloud.Data.Entities.Enums;
using System.Collections.Generic;

namespace BankCloud.Data.Entities
{
    public class Account
    {
        public Account()
        {
            this.Loans = new HashSet<Loan>();
            //this.Мovements = new HashSet<Мovement>();
        }

        public string Id { get; set; }

        public string IBAN { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutcome { get; set; }

        public decimal Balance { get; set; }

        public string BankUserId { get; set; }
        public BankUser BankUser { get; set; }

        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }

        //public ICollection<Мovement> Мovements { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
