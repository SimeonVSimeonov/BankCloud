using BankCloud.Data.Entities;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface IAccountsService
    {
        IEnumerable<Account> GetUserAccounts();

        IEnumerable<string> GetUserAccountsIds();
    }
}
