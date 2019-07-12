namespace BankCloud.Models.ViewModels
{
    public class LoanDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal InterestRate { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public string Seller { get; set; }

        public string CurencyIso { get; set; }

        public string CurencyName { get; set; }

        public decimal Price { get; set; }
    }
}
