using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.BindingModels
{
    public class AccountsChargeInputModel
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string ChargeType { get; set; }

    }
}
