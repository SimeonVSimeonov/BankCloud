namespace BankCloud.Models.BindingModels
{
    public class LoanOrderInputModel
    {
        public int Period { get; set; }

        public decimal Amount { get; set; }

        public decimal Installment { get; set; }

    }
}
