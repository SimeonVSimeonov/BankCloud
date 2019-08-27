using BankCloud.Data.Entities.Enums;
using System;

namespace BankCloud.Data.Entities
{
    public class Transfer
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public decimal? ConvertedAmount { get; set; }

        public BalanceType BalanceType { get; set; }

        public TransferStatus Status { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Completed { get; set; }

        public TransferType Type { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string ForeignAccountId { get; set; }
        public Account ForeignAccount { get; set; }
    }
}
