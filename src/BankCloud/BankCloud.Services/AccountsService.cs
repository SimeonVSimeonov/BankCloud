using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using BankCloud.Services.Common;

namespace BankCloud.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly BankCloudDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountsService(BankCloudDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public object GetAccountById(string id)
        {
            return this.context.Accounts
                .Include(account => account.Currency)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return this.context.Currencies;
        }

        public IEnumerable<Account> GetUserAccounts()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Accounts
                .Where(account => account.BankUserId == userId)
                .Include(account => account.Transfers)
                .Include(account => account.Payments)
                .Include(account => account.Currency)
                .ToList();
        }

        public IEnumerable<string> GetUserAccountsIds()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Accounts
                .Where(account => account.BankUserId == userId)
                .Select(account => account.Id);
        }

        public void AddAccountToUser(Account account)
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            account.IBAN = IbanGenerator.Generate();

            BankUser userFromDb = this.context.Users.Find(userId);
            userFromDb.Accounts.Add(account);

            this.context.SaveChanges();
        }

        public Account GetAccountByIban(string iban)
        {
            return this.context.Accounts.SingleOrDefault(x => x.IBAN == iban);
        }
    }
}
