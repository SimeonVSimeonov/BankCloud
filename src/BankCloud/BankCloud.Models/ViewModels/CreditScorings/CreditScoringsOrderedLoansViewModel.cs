﻿namespace BankCloud.Models.ViewModels.CreditScorings
{
    public class CreditScoringsOrderedLoansViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AdUrl { get; set; }

        public string Buyer { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal Commission { get; set; }

        public decimal MonthlyFee { get; set; }

        public string Currency { get; set; }
    }
}
