namespace BankCloud.Models.BindingModels.Common
{
    public class LoanConstants
    {
        public const string LoanAmountMinValue = "0.01";
        public const string LoanAmountMaxValue = "1000000000";

        public const string LoanRateMinValue = "0.01";
        public const string LoanRateMaxValue = "100";

        public const string LoanCommissionMinValue = "0.01";
        public const string LoanCommissionMaxValue = "100";

        public const int LoanPeriodMinValue = 1;
        public const int LoanPeriodMaxValue = int.MaxValue;
    }
}
