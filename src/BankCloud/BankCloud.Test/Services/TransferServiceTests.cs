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
    public class TransferServiceTests
    {
        [Fact]
        public void GetTransferByIdShouldReturnCorrectTransfer()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
               .UseInMemoryDatabase(databaseName: "GetTransferById_Database")
               .Options;

            var dbContext = new BankCloudDbContext(options);

            var transferService = new TransferService(dbContext, null, null, null);

            var transferId = "123abc";
            var transfer = new Transfer { Id = transferId };
            dbContext.Transfers.Add(transfer);
            dbContext.SaveChanges();

            var returnedTransfer = transferService.GetTransferById(transferId);

            Assert.Equal(transfer, returnedTransfer);
        }

        [Fact]
        public void AddBankCloudTransferShouldAddBankCloudTran()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "GetTransferById_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var transferService = new TransferService(dbContext, null, null, null);

            var transferId = "123abc";
            var transfer = new Transfer { Id = transferId };
            transferService.AddBankCloudTransfer(transfer);

            var transfers = dbContext.Transfers.ToList();
            var returnedTransfer = dbContext.Transfers.Find(transferId);

            Assert.Single(transfers);
            Assert.Equal(transfer, returnedTransfer);
        }

        [Fact]
        public void GetPaymentsByAccountIdShouldReturnPaymentsForAccount()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "GetPaymentsByAccount_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var transferService = new TransferService(dbContext, null, null, null);

            var accountId = "123abc";
            var account = new Account { Id = accountId};
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            dbContext.Payments.AddRange(new List<Payment>
            {
                new Payment{AccountId = accountId},
                new Payment{AccountId = accountId},
                new Payment{},
                new Payment{}
            });
            dbContext.SaveChanges();

            var payments =  transferService.GetPaymentsByAccountId(accountId);

            Assert.Equal(2, payments.Count());
        }
    }
}
