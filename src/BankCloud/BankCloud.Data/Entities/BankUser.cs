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

            //this.OrderedInsurances = new HashSet<OrderInsurance>();
            //this.OrderedLoans = new HashSet<OrderLoan>();
            //this.OrderedSaves = new HashSet<OrderSave>();
            //this.OrderedInvestments = new HashSet<OrderInvestment>();
            //this.OrderedPayments = new HashSet<OrderPayment>();
            this.Orders = new HashSet<Order>();
        }

        [Required]
        public string Name { get; set; }

        public string Middlename { get; set; }

        public string Surname { get; set; }

        public string IdentityNumber { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        public bool IsActive { get; set; }

        public bool IsAgent { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<CreditScoring> CreditScorings { get; set; }

        public ICollection<Order> Orders { get; set; }

        //public ICollection<OrderInsurance> OrderedInsurances { get; set; }
        //public ICollection<OrderLoan> OrderedLoans { get; set; }
        //public ICollection<OrderSave> OrderedSaves { get; set; }
        //public ICollection<OrderInvestment> OrderedInvestments { get; set; }
        //public ICollection<OrderPayment> OrderedPayments { get; set; }
    }
}
