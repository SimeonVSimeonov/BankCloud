namespace BankCloud.Models.BindingModels
{
    public class LoanOrderInputModel
    {
        public string Id { get; set; }

        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal MonthlyFee { get; set; }

        public decimal Commission { get; set; }

        public decimal InterestRate { get; set; }

        public string CurencyId { get; set; }

    }
}
