﻿namespace BankCloud.Models.ViewModels.Orders
{
    public class OrderedSavesDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Seller { get; set; }

        public string Status { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public string IssuedOn { get; set; }

        public string CompletedOn { get; set; }

        public string CurrencyIso { get; set; }

        public decimal Commission { get; set; }

        public decimal MonthlyFee { get; set; }

        public decimal DueAmount { get; set; }

        public string Account { get; set; }
    }
}
