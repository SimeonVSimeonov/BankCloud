using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Services.Interfaces
{
    public interface IOrdersService
    {
        void AddOrderLoan(OrderLoan order);

        IEnumerable<OrderLoan> GetOrderedLoansByUser();

        OrderLoan GetOrderLoanById(string id);
    }
}
