﻿using BankCloud.Models.ViewModels.Users;
using System;

namespace BankCloud.Models.BindingModels.CreditScorings
{
    public class CreditScoringsLoanInputModel
    {
        //TODO: validation
        public string Id { get; set; }

        public string Status { get; set; }

        public DateTime CompletedOn { get; set; }

        public UsersAccountViewModel Seller { get; set; }

        public UsersAccountViewModel Buyer { get; set; }
    }
}
