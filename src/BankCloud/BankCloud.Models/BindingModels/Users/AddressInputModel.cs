using System.ComponentModel.DataAnnotations;

namespace BankCloud.Models.BindingModels.Users
{
    public class AddressInputModel
    {
        private const int CountryNameMinLength = 2;
        private const int CountryNameMaxLength = 30;

        private const int CityNameMinLength = 2;
        private const int CityNameMaxLength = 30;

        private const int StreetNameMinLength = 2;
        private const int StreetNameMaxLength = 30;

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string City { get; set; }

        [Required]
        [StringLength(StreetNameMaxLength, MinimumLength = StreetNameMinLength)]
        public string Street { get; set; }
    }
}
