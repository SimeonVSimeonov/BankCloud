namespace BankCloud.Services.Common
{
    public class GlobalConstants
    {
        public const string SAVE = "Save";

        public const string LOAN = "Loan";

        public const string INSURANCE = "Insurance";

        public const string INVESTMENT = "Investment";

        public const string ORDER_LOAN = "OrderLoan";

        public const string ORDER_SAVE = "OrderSave";

        public const string ORDER_INSURANCE = "OrderInsurance";

        public const string ORDER_INVESTMENT = "OrderInvestment";

        public const string ERROR_MESSAGE_FOR_INSUFFICIENT_FUNDS = "Insufficient Funds Please Recharge Your Accounts!!!";

        public const string ERROR_MESSAGE_FOR_DEPOSITOR_DOES_NOT_HAVE_MONEY = "Depositor does not have enough money for the transaction!!!";

        public const string INVALID_BANKCLOUD_IBAN_NUMBER = "Please enter a valid BankCloud IBAN number!!!";

        public const string MISSING_BANKCLOUD_ACCOUNT = "An BankCloud account with that IBAN does not exist!!!";
    }
}
