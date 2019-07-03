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
            this.Loans = new HashSet<Loan>();
            this.Insurances = new HashSet<Insurance>();
            this.Orders = new HashSet<Order>();
            this.CreditScorings = new HashSet<CreditScoring>();
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

        public bool IsAgent { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<CreditScoring> CreditScorings { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Loan> Loans { get; set; }

        public ICollection<Insurance> Insurances { get; set; }

        public ICollection<Save> Saves { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Investment> Investments { get; set; }
    }
}
