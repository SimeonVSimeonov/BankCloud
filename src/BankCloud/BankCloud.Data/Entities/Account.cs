using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Account
    {
        public string Id { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal Balance { get; set; }

        public string CurencyId { get; set; }
        public Curency Curency { get; set; }
    }
}
