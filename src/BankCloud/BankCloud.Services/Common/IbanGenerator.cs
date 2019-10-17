using System;
using System.Text;

namespace BankCloud.Services.Common
{
    public class IbanGenerator
    {
        public static string Generate()
        {
            var sb = new StringBuilder();
            sb.Append(GlobalConstants.IBAN_PREFIX);
            var num = new Random();

            for (int i = 0; i <= 3; i++)
            {
                sb.Append(GlobalConstants.IBAN_NUMBER_WHITESPACE);
                sb.Append(num.Next(1000, 9999));
            }

            return (sb.ToString());
        }
    }
}
