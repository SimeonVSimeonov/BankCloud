using BankCloud.Data.Entities.Enums;
using System;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountsChargeInputModel
    {
        //TODO: validation
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime Completed { get; set; }

        public string Account { get; set; }

    }
}
