﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Save
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string SellerID { get; set; }
        public BankUser Seller { get; set; }

        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
