using BankCloud.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels.Accounts
{
    public class TransfersDetailViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Recipient { get; set; }

        public string RecipientIban { get; set; }

        public decimal Amount { get; set; }

        public string IsoCode { get; set; }

        public decimal ConvertedAmount { get; set; }

        public BalanceType BalanceType { get; set; }

        public TransferStatus Status { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Completed { get; set; }

        public TransferType Type { get; set; }

        public string AccountId { get; set; }

        public string ForeignAccountId { get; set; }

    }
}
