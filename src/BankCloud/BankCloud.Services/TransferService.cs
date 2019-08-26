using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Services.Interfaces;

namespace BankCloud.Services
{
    public class TransferService : ITransferService
    {
        private readonly BankCloudDbContext context;

        public TransferService(BankCloudDbContext context)
        {
            this.context = context;
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
    }
}
