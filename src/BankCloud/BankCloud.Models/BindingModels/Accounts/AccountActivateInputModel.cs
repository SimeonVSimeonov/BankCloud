using BankCloud.Models.BindingModels.Users;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountActivateInputModel
    {
        private const string SpecifyMiddlename = "Specify your Middle Name";
        private const string SpecifySurname = "Specifyr your Surname";
        private const string SpecifyPhoneNumber = "Specify your Phone Number";
        private const string SpecifyIdentityNumber = "Specifyr your Identity Number";
        private const string SpecifyAvatarPic = "Specify a avatar picture for your account";

        private const int SurnameMinLength = 3;
        private const int SurnameMaxLength = 18;

        private const int IdentityNumberMinLength = 8;
        private const int IdentityNumberMaxLength = 20;

        [Display(Name = SpecifyMiddlename)]
        public string Middlename { get; set; }

        [Required]
        [StringLength(SurnameMaxLength, MinimumLength = SurnameMinLength)]
        [Display(Name = SpecifySurname)]
        public string Surname { get; set; }

        [Required]
        [Phone]
        [Display(Name = SpecifyPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(IdentityNumberMaxLength, MinimumLength = IdentityNumberMinLength)]
        [Display(Name = SpecifyIdentityNumber)]
        public string IdentityNumber { get; set; }

        [Required]
        [Display(Name = SpecifyAvatarPic)]
        public IFormFile AdUrl { get; set; }

        [Required]
        public AddressInputModel Address { get; set; }

        [Required]
        public AccountInputModel Account { get; set; }
    }
}
