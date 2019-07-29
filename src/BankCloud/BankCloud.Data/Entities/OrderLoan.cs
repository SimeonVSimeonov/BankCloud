using BankCloud.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class OrderLoan : Order
    {
        public string LoanId { get; set; }
        public Loan Loan {get; set;}
    }
}
