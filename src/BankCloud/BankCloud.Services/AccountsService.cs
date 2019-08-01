using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using BankCloud.Services.Common;
using BankCloud.Models.BindingModels;

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
    }
}
