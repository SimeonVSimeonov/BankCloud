using BankCloud.Data.Entities;
using FixerSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankCloud.Services.Interfaces
{
    public interface IOrdersService
    {
        Order GetOrderById(string id);

        void AddOrderLoan(OrderLoan order, Product loan);
        void AddOrderSave(OrderSave order, Product save);

        void RejectRequest(Order order);

        void ApproveLoanRequest(OrderLoan orderLoan);
        void ApproveSaveRequest(OrderSave orderedSave);

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
        OrderSave GetSoldOrderSaveById(string id);
    }
}
