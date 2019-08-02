using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.BindingModels
{
    public class AccountsChargeInputModel
    {

        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime Completed { get; set; }

        public string Account { get; set; }

    }
}
