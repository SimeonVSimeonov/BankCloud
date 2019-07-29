using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class OrderSave : Order
    {
        public string SaveId { get; set; }
        public Save Save { get; set; }
    }
}
