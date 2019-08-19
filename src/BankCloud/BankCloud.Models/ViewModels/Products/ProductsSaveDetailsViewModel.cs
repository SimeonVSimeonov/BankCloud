namespace BankCloud.Models.ViewModels.Products
{
    public class ProductsSaveDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public string Seller { get; set; }

        public string SellerEmail { get; set; }

        public string CurrencyIso { get; set; }

        public string CurrencyName { get; set; }

        public decimal PenaltyInterest { get; set; }
    }
}
