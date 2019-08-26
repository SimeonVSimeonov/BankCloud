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
    }
}
