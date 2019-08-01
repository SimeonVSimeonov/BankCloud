namespace BankCloud.Models.BindingModels
{
    public class AccountInputModel
    {
        public string IBAN { get; set; }

        //public decimal Charge { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }
    }
}
