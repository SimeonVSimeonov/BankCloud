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
                TransferId = transfer.Id,
                Status = PaymentStatus.Pending
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
                model.ConvertedAmount = model.Amount;
            }

            Transfer transfer = this.mapper.Map<Transfer>(model);
            transfer.ForeignAccountId = receiverAccount.Id;
            transfer.Date = DateTime.UtcNow;
            transfer.Completed = DateTime.UtcNow;
            transfer.Type = TransferType.BankCloud;
            transfer.Status = TransferStatus.Approved;
            transfer.BalanceType = BalanceType.Negative;

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

        public void DoApproveTransfer(Transfer transfer, Account grantAccount, Account receiverAccount)
        {

            if (receiverAccount.CurrencyId != grantAccount.CurrencyId)
            {
                receiverAccount.Balance += transfer.Amount;
                grantAccount.Balance -= transfer.ConvertedAmount;
            }
            else
            {
                receiverAccount.Balance += transfer.Amount;
                grantAccount.Balance -= transfer.Amount;
            }

            transfer.Status = TransferStatus.Approved;
            transfer.Completed = DateTime.UtcNow;

            var payment = this.context.Payments.SingleOrDefault(x => x.TransferId == transfer.Id);
            payment.Status = PaymentStatus.Approved;

            this.context.SaveChanges();
        }

        public void DoRejectTransfer(Transfer transfer, Account grantAccount, Account receiverAccount)
        {
            transfer.Completed = DateTime.UtcNow;
            transfer.Status = TransferStatus.Rejected;

            var payment = this.context.Payments.SingleOrDefault(x => x.TransferId == transfer.Id);
            payment.Status = PaymentStatus.Rejected;

            this.context.SaveChanges();
        }

        public IEnumerable<Transfer> GetTransfers(string id)
        {
            return this.context.Payments
                 .Select(x => x.Transfer)
                 .Include(transfer => transfer.Account)
                 .ThenInclude(account => account.BankUser)
                 .Where(x => x.ForeignAccountId == id);
        }

        public IEnumerable<Transfer> GetCharges(string id)
        {
            string userId = httpContextAccessor.HttpContext.User
               .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Transfers
               .Include(transfer => transfer.Account)
               .ThenInclude(account => account.BankUser)
               .Include(transfer => transfer.ForeignAccount)
               .ThenInclude(account => account.BankUser)
               .Include(x => x.ForeignAccount.Currency)
               .Where(x => x.AccountId == id || x.Account.BankUserId == userId);
        }
    }
}
