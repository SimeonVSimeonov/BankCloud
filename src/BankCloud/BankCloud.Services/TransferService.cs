using AutoMapper;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Accounts;
using BankCloud.Services.Interfaces;
using FixerSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BankCloud.Services
{
    public class TransferService : ITransferService
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BankCloudDbContext context;
        private readonly IAccountsService accountsService;


        public TransferService(BankCloudDbContext context, IHttpContextAccessor httpContextAccessor,
            IAccountsService accountsService, IMapper mapper)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.accountsService = accountsService;
            this.mapper = mapper;
        }

        public Transfer GetTransferById(string id)
        {
           return this.context.Transfers
                .Include(transfer => transfer.Account)
                .Include(transfer => transfer.ForeignAccount)
                .SingleOrDefault(x => x.Id == id);
        }

        public void AddBankCloudTransfer(Transfer transfer)
        {
            transfer.Status = TransferStatus.Pending;

            this.context.Transfers.Add(transfer);
            Payment payment = new Payment
            {
                AccountId = transfer.ForeignAccountId,
                TransferId = transfer.Id
            };

            this.context.Payments.Add(payment);

            this.context.SaveChanges();
        }

        public void DoTransfer(TransferBankCloudInputModel model,
            Account grantAccount, Account receiverAccount)
        {
            
            grantAccount.Balance -= model.Amount;

            if (receiverAccount.CurrencyId != grantAccount.CurrencyId)
            {
                ExchangeRate rateFromTo = Fixer
                    .Rate(grantAccount.Currency.IsoCode, receiverAccount.Currency.IsoCode);
                var convertAmmount = rateFromTo.Convert((double)model.Amount);
                receiverAccount.Balance += (decimal)convertAmmount;
                model.ConvertedAmount = (decimal)convertAmmount;
            }
            else
            {
                receiverAccount.Balance += model.Amount;
            }

            Transfer transfer = this.mapper.Map<Transfer>(model);
            transfer.Date = DateTime.UtcNow;
            transfer.Completed = DateTime.UtcNow;
            transfer.Status = TransferStatus.Approved;

            this.context.Transfers.Add(transfer);
            this.context.SaveChanges();
        }

        public IEnumerable<Payment> GetPaymentsByAccountId(string id)
        {
            return this.context.Payments
                .Where(payment => payment.AccountId == id)
                .Include(payment => payment.Transfer)
                .ThenInclude(transfer => transfer.Account)
                .ThenInclude(account => account.BankUser);
        }

        public void ApproveTransfer(Transfer transfer, Account grantAccount, Account receiverAccount)
        {
            grantAccount.Balance -= transfer.ConvertedAmount;
            receiverAccount.Balance += transfer.ConvertedAmount;
            transfer.Status = TransferStatus.Approved;
            transfer.Completed = DateTime.UtcNow;

            var payments = this.context.Payments.SingleOrDefault(x => x.TransferId == transfer.Id);
            this.context.Payments.Remove(payments);

            this.context.SaveChanges();
        }

        public IEnumerable<Transfer> GetTransfers(string id)
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Transfers
                .Include(transfer => transfer.Account)
                .ThenInclude(account => account.BankUser)
                .Where(x => x.ForeignAccountId == id);
        }
    }
}
