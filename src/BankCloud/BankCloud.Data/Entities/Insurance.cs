using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Insurance
    {
        public Insurance()
        {
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public InsuranceType Type { get; set; }

        public decimal Installment { get; set; }

        public decimal Coverage { get; set; }

        public string SellerID { get; set; }
        public BankUser Seller { get; set; }

        public string CurencyId { get; set; }
        public Curency Curency { get; set; }
    }
}
