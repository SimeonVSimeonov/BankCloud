using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels
{
    public class LoanOrderInputModel
    {
        public string Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Period { get; set; }

        public decimal Amount { get; set; }

        [Display(Name = "Monthly Fee")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MonthlyFee { get; set; }

        public decimal Commission { get; set; }

        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }

        public string CurencyId { get; set; }

        public string AccountId { get; set; }
    }
}
