using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels.Accounts;

namespace BankCloud.Services.Interfaces
{
    public interface ITransferService
    {
        void AddBankCloudTransfer(Transfer transfer);
        void DoTransfer(TransferBankCloudInputModel model, Account grantAccount, Account receiverAccount);
    }
}
