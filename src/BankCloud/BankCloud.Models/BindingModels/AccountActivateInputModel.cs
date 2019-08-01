using BankCloud.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class AccountActivateInputModel
    {

        [Display(Name = "Specify your Middle Name")]
        public string Middlename { get; set; }

        [StringLength(18, MinimumLength = 3)]
        [Display(Name = "Specifyr your Surname")]
        public string Surname { get; set; }

        [Phone]
        [Display(Name = "Specify your Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Specifyr your Identity Number")]
        public string IdentityNumber { get; set; }

        //[Required] TODO:
        public AddressInputModel Address { get; set; }

        //[Required] TODO:
        public AccountInputModel Account { get; set; }
    }
}
