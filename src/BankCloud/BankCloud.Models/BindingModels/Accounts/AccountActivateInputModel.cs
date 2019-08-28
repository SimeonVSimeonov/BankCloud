﻿using BankCloud.Models.BindingModels.Users;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Accounts
{
    public class AccountActivateInputModel
    {

        [Display(Name = "Specify your Middle Name")]
        public string Middlename { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 3)]
        [Display(Name = "Specifyr your Surname")]
        public string Surname { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Specify your Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Specifyr your Identity Number")]
        public string IdentityNumber { get; set; }

        [Required]
        [Display(Name = "Specify a avatar picture for your account")]
        public IFormFile AdUrl { get; set; }

        [Required]
        public AddressInputModel Address { get; set; }

        [Required]
        public AccountInputModel Account { get; set; }
    }
}
