using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels
{
    public class UsersOrderedLoansViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AdUrl { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public string Status { get; set; }

        public string Feedback { get; set; }

        public string CurrencyIso { get; set; }
    }
}
