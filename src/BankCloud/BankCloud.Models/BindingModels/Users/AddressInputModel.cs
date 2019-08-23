using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Users
{
    public class AddressInputModel
    {
        [StringLength(30, MinimumLength = 2)]
        public string Country { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string Street { get; set; }
    }
}
