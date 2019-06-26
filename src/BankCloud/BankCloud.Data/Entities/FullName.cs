using System.ComponentModel.DataAnnotations;

namespace BankCloud.Data.Entities
{
    public class FullName
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Middlename { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}