using BankCloud.Data.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCloud.Data.Entities
{
    public class Account
    {
        public Account()
        {
            this.Transfers = new HashSet<Transfer>();
            this.Payments = new HashSet<Payment>();
        }

        public string Id { get; set; }

        public string IBAN { get; set; }

        public string AdUrl { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal MonthlyOutcome { get; set; }

        public decimal Balance { get; set; }

        public string BankUserId { get; set; }
        public BankUser BankUser { get; set; }

        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public ICollection<Transfer> Transfers { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
