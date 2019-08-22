using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Services.Interfaces
{
    public interface IOrdersService
    {
        void AddOrderLoan(OrderLoan order, Product loan);
        void AddOrderSave(OrderSave order, Product save);

        void RejectRequest(OrderLoan order);

        void ApproveRequest(OrderLoan orderLoan);

        IEnumerable<Order> GetAllOrderedByCurrentUser();

        IEnumerable<OrderLoan> GetOrderedLoansByCurrentUser();
        IEnumerable<OrderSave> GetOrderedSavesByCurrentUser();

        IEnumerable<string> GetAgentOrderLoansIds();
        IEnumerable<string> GetAgentOrderSavesIds();

        OrderLoan GetOrderLoanById(string id);
        OrderSave GetOrderSaveById(string id);

        IEnumerable<OrderLoan> GetSoldOrderLoans();
        IEnumerable<OrderSave> GetSoldOrderSaves();

        OrderLoan GetSoldOrderLoanById(string id);
    }
}
