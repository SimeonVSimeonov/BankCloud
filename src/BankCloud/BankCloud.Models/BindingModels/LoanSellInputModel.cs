namespace BankCloud.Models.BindingModels
{
    public class LoanSellInputModel
    {
        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public string Seller { get; set; }

        public string Curency { get; set; }
    }
}
