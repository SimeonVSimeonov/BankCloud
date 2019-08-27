using AutoMapper;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Accounts;
using BankCloud.Services.Interfaces;
using FixerSharp;
using System;

namespace BankCloud.Services
{
    public class TransferService : ITransferService
    {
        private readonly IMapper mapper;
        private readonly BankCloudDbContext context;
        private readonly IAccountsService accountsService;


        public TransferService(BankCloudDbContext context,
            IAccountsService accountsService, IMapper mapper)
        {
            this.context = context;
            this.accountsService = accountsService;
            this.mapper = mapper;
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
    }
}
