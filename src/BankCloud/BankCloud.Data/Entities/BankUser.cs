using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class BankUser : IdentityUser
    {
        public BankUser()
        {
            this.Accounts = new HashSet<Account>();
            this.CreditScorings = new HashSet<CreditScoring>();

            this.OrderedInsurances = new HashSet<OrderInsurances>();
            this.OrderedLoans = new HashSet<OrderLoan>();
            this.OrderedSaves = new HashSet<OrderSaves>();
            this.OrderedInvestments = new HashSet<OrderInvestments>();
            this.OrderedPayments = new HashSet<OrderPayments>();
        }

        [Required]
        public string Name { get; set; }

        public string Middlename { get; set; }

        //[Required] TODO:
        public string Surname { get; set; }

        //[Required] TODO:
        public string IdentityNumber { get; set; }

        //[Required] TODO:
        public string AddressId { get; set; }
        public Address Address { get; set; }

        public bool IsActive { get; set; }

        public bool IsAgent { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<CreditScoring> CreditScorings { get; set; }

        public ICollection<OrderInsurances> OrderedInsurances { get; set; }
        public ICollection<OrderLoan> OrderedLoans { get; set; }
        public ICollection<OrderSaves> OrderedSaves { get; set; }
        public ICollection<OrderInvestments> OrderedInvestments { get; set; }
        public ICollection<OrderPayments> OrderedPayments { get; set; }


    }
}
