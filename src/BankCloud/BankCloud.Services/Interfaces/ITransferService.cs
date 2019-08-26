using BankCloud.Data.Entities;

namespace BankCloud.Services.Interfaces
{
    public interface ITransferService
    {
        void AddBankCloudTransfer(Transfer transfer);
    }
}
