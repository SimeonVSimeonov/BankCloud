using BankCloud.Data.Attributes;

namespace BankCloud.Data.Entities.Enums
{
    public enum TransferType
    {
        [DisplayText("BankCloud Account")]
        BankCloud = 1,

        [DisplayText("With a Card From Another Bank ")]
        Card = 2,
    }

}
