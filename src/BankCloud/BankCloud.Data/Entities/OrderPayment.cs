using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderPayment
    {
        public string Id { get; set; }

        public string PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
