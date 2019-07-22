using BankCloud.Data.Entities;

namespace BankCloud.Models.BindingModels
{
    public class AccountActivateInputModel
    {

        public string Middlename { get; set; }

        //[Required] TODO:
        public string Surname { get; set; }

        //[Required] TODO:
        public string PhoneNumber { get; set; }

        //[Required] TODO:
        public string IdentityNumber { get; set; }

        //[Required] TODO:
        public AddressInputModel Address { get; set; }

        //[Required] TODO:
        public AccountInputModel Account { get; set; }
    }
}
