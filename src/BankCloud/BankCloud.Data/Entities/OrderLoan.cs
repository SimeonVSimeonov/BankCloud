using System.ComponentModel.DataAnnotations.Schema;

namespace BankCloud.Data.Entities
{
    public class OrderLoan : Order
    {
        public string LoanId { get; set; }
        public Loan Loan {get; set;}
    }
}
