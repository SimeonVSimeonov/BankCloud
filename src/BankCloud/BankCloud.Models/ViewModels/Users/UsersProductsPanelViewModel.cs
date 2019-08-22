using BankCloud.Models.ViewModels.Orders;
using System.Collections.Generic;

namespace BankCloud.Models.ViewModels.Users
{
    public class UsersProductsPanelViewModel
    {
        public IEnumerable<string> Type { get; set; }

        public IEnumerable<UsersProductsViewModel> Products { get; set; }

        public IEnumerable<AllOrdersViewModel> Orders { get; set; }

    }
}
