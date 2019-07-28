namespace BankCloud.Data.Entities
{
    public class Payment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string SellerID { get; set; }
        public BankUser Seller { get; set; }

        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
