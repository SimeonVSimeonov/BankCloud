using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace BankCloud.Test.Services
{
    public class AccountsServiceTests
    {
        [Fact]
        public void GetAccountByIdShouldReturnCoreectedAccount()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_AccountServices_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);
            var account = new Account { Id = "ABCD" };
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();

            var accountService = new AccountsService(dbContext, null);
            var returnedAccount = accountService.GetAccountById(account.Id);

            Assert.Equal(account.Id, returnedAccount.Id);

        }

        [Fact]
        public void GetCurrenciesShouldReturnAllCurrencies()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
               .UseInMemoryDatabase(databaseName: "Currencies_AccountServices_Database")
               .Options;

            var dbContext = new BankCloudDbContext(options);

            var currencies = new List<Currency>
            {
                new Currency{Id = "a"},
                new Currency{Id = "b"},
                new Currency{Id = "c"}
            };
            dbContext.AddRange(currencies);
            dbContext.SaveChanges();

            var accountService = new AccountsService(dbContext, null);
            var returnedCurrencies = accountService.GetCurrencies();

            Assert.Equal(3, returnedCurrencies.Count());
            Assert.Equal(currencies, returnedCurrencies);
        }

        [Fact]
        public void GetAccountByIbanShouldReturnCorectAccount()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
               .UseInMemoryDatabase(databaseName: "AccountByIban_AccountServices_Database")
               .Options;

            var dbContext = new BankCloudDbContext(options);

            var account = new Account { IBAN = "CLD 1234 5478" };
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();

            var accountService = new AccountsService(dbContext, null);
            var returnedAccount = accountService.GetAccountByIban(account.IBAN);

            Assert.Equal(account, returnedAccount);

        }
    }
}
