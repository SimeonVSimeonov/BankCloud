using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.BindingModels
{
    public class LoanSellInputModel
    {
        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public DateTime Period { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public Curency Curency { get; set; }
    }
}
