using BankCloud.Models.ViewModels.Users;
using System.Collections.Generic;

namespace BankCloud.Models.ViewModels.Orders
{
    public class OrdersProductsPanelViewModel
    {
        public IEnumerable<string> Type { get; set; }

        public IEnumerable<UsersOrderedLoansViewModel> OrderedLoans { get; set; }
        public IEnumerable<UsersOrderedSavesViewModel> OrderedSaves { get; set; }
    }
}
