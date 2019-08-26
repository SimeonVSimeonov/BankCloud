using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Data.Entities
{
    public class Payment
    {
        public string Id { get; set; }

        public string TransferId { get; set; }
        public Transfer Transfer { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
