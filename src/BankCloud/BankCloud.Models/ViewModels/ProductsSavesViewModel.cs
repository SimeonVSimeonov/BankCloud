using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels
{
    public class ProductsSavesViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AdUrl { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public string Currency { get; set; }
    }
}
