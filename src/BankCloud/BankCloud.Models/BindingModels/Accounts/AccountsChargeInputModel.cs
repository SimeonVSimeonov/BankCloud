using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountsChargeInputModel
    {
        //TODO: validation
        public string Id { get; set; }

        [Display(Name = "Specify a maximum amount")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public TransferType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public DateTime Completed { get; set; }

        public string Account { get; set; }

    }
}
