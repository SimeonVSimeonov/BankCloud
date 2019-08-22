using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Services.Common
{
    public class BankCloudCalculator
    {
        public static decimal CalculateMounthlyFee(Product product)
        {
            if (product.Period <= 0)
            {
                throw new InvalidOperationException();//TODO: show error for this case
            }

            return decimal
                .Round(((product.Amount / product.Period) * ((product.InterestRate / 100) + 1)),
                                                                         2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalculateCommission(Product product)
        {
            return product.Commission * product.Amount / 100;
        }

        public static decimal CalculateDepositMonthlyIncome(OrderSave order, Product save)
        {
            return (order.Amount / 100) * save.InterestRate;
        }
    }
}
