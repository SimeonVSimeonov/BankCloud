namespace BankCloud.Models.BindingModels.Users
{
    public class AddressInputModel
    {
        //TODO: validation
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
