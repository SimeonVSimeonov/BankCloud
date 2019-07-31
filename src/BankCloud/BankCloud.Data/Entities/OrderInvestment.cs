using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderInvestment : Order
    {
        public string InvestmentId { get; set; }
        public Investment Investment { get; set; }
    }
}
