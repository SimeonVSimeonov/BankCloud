using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels.Accounts;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface ITransferService
    {
        void AddBankCloudTransfer(Transfer transfer);
        void DoTransfer(TransferBankCloudInputModel model, Account grantAccount, Account receiverAccount);
        IEnumerable<Payment> GetPaymentsByAccountId(string id);
        Transfer GetTransferById(string id);
        void ApproveTransfer(Transfer transfer, Account grantAccount, Account receiverAccount);
        IEnumerable<Transfer> GetTransfers(string id);
        IEnumerable<Transfer> GetCharges(string id);
    }
}
