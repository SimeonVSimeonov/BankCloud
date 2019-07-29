using BankCloud.Data.Entities.Enums;

namespace BankCloud.Data.Entities
{
    public class Insurance : Product
    {
        public InsuranceType Type { get; set; }

        public decimal Installment { get; set; }
    }
}
