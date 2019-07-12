using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Loan
    {
        public Loan()
        {
            this.Orders = new HashSet<Order>();
            
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public string BankUserId { get; set; }
        public BankUser Seller { get; set; }

        public string CurencyId { get; set; }
        public Curency Curency { get; set; }

        public string OrderId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
