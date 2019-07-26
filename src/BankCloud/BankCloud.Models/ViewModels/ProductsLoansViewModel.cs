﻿namespace BankCloud.Models.ViewModels
{
    public class ProductsLoansViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public string Curency { get; set; }

    }
}