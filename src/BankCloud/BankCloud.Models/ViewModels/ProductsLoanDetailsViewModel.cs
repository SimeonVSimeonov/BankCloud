namespace BankCloud.Models.ViewModels
{
    public class ProductsLoanDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public string Seller { get; set; }

        public string SellerEmail { get; set; }

        public string CurrencyIso { get; set; }

        public string CurrencyName { get; set; }

        public decimal Commission { get; set; }
    }
}
