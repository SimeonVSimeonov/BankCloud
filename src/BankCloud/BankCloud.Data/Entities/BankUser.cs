using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class BankUser : IdentityUser
    {
        public BankUser()
        {
            this.Products = new HashSet<Product>();
            this.Orders = new HashSet<Order>();
            this.CreditScorings = new HashSet<CreditScoring>();
        }


        //[Required]
        public string FullNameId { get; set; }
        public FullName FullName { get; set; }

        //[Required] TODO add this to other entity
        public string IdentityNumber { get; set; }

        //[Required] TODO add this to other entity
        public string AddressId { get; set; }
        public Address Address { get; set; }

        public string OptionalAddressId { get; set; }
        public Address OptionalAddress { get; set; }

        public ICollection<CreditScoring> CreditScorings { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
