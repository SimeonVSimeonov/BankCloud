using System;
using System.Text;

namespace BankCloud.Services.Common
{
    public class IbanGenerator
    {
        public static string Generate()
        {
            var sb = new StringBuilder();
            sb.Append("CLD");
            var num = new Random();

            for (int i = 0; i <= 3; i++)
            {
                sb.Append(" ");
                sb.Append(num.Next(1000, 9999));
            }

            return (sb.ToString());
        }
    }
}
