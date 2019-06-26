using BankCloud.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class Product
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Asset { get; set; }

        public decimal Liabilities { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public string ProductCurencyId { get; set; }
        public Curency ProductCurency { get; set; }

        [Required]
        public string TypeId { get; set; }
        public ProductType Type { get; set; }
    }
}