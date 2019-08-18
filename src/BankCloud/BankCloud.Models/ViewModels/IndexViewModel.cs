using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Models.ViewModels
{
    public class IndexViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime IssuedOn { get; set; }

        public string AdUrl { get; set; }

    }
}
