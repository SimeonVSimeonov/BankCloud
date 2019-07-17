using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels
{
    public class MyOrderedLoansViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public string Status { get; set; }
    }
}
