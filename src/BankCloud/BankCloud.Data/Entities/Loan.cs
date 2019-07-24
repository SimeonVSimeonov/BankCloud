using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Loan
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal Commission { get; set; }

        public string SellerID { get; set; }
        public BankUser Seller { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
