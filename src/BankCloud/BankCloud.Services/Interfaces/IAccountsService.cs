using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface IAccountsService
    {
        IEnumerable<Account> GetUserAccounts();
        IEnumerable<string> GetUserAccountsIds();
        IEnumerable<Currency> GetCurrencies();
        void AddAccountToUser(Account account);
        Account GetAccountByIban(string iban);
        Account GetAccountById(string id);
    }
}
