using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Users
{
    public class AddressInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Street { get; set; }
    }
}
