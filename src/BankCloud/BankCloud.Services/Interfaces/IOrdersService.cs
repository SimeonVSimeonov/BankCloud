using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Services.Interfaces
{
    public interface IOrdersService
    {
        void AddOrderLoan(OrderLoan order);

        void RejectRequest(OrderLoan order);

        IEnumerable<OrderLoan> GetOrderedLoansByCurrentUser();

        IEnumerable<string> GetAgentOrderLoansIds();

        OrderLoan GetOrderLoanById(string id);

        IEnumerable<OrderLoan> GetSoldOrderLoans();

        OrderLoan GetSoldOrderLoanById(string id);

    }
}
