using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderInsurance : Order
    {
        public string InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}
