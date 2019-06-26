using BankCloud.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class Curency
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string IsoCode { get; set; }

        public CurencyType Type { get; set; }

        [Required]
        [Range(0, 10)]
        public int ТrustLevel { get; set; }

         //TODO: - Exchange (calc prop)
    }
}