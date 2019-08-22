using System;

namespace BankCloud.Models.ViewModels.Home
{
    public class IndexViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime IssuedOn { get; set; }

        public string AdUrl { get; set; }

        public int Popularity { get; set; }

    }
}
