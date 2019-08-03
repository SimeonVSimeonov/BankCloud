using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BankCloud.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly BankCloudDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrdersService(BankCloudDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void AddOrderLoan(OrderLoan orderLoan)
        {
            if (orderLoan == null)
            {
                return;
            }

            context.OrdersLoans.Add(orderLoan);
            context.SaveChanges();
        }

        public void RejectRequest(OrderLoan orderLoan)
        {
            if (orderLoan == null)
            {
                return;
            }

            orderLoan.CompletedOn = DateTime.UtcNow;
            orderLoan.Status = OrderStatus.Rejected;

            this.context.SaveChanges();
        }

        public IEnumerable<string> GetAgentOrderLoansIds()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersLoans
                .Where(orderedLoan => orderedLoan.Status == OrderStatus.Pending &&
                    orderedLoan.Account.BankUserId == userId)
                .Select(orderedLoan => orderedLoan.Id);
        }

        public IEnumerable<OrderLoan> GetOrderedLoansByCurrentUser()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersLoans
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account.Currency)
                .Where(order => order.Account.BankUserId == userId)
                .Include(orderLoan => orderLoan.Account.Currency);
        }

        public OrderLoan GetOrderLoanById(string id)
        {
            return this.context.OrdersLoans
                .Include(orderLoan => orderLoan.Account)
                .ThenInclude(account => account.Currency)
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account)
                .ThenInclude(account => account.Currency)
                .Include(orderLoan => orderLoan.Loan.Account.BankUser)
                .SingleOrDefault(orderLoan => orderLoan.Id == id);
        }

        public OrderLoan GetSoldOrderLoanById(string id)
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersLoans
                .Include(orderedLoan => orderedLoan.Account.BankUser)
                .ThenInclude(buyer => buyer.Accounts)
                .ThenInclude(loan => loan.Currency)
                .Include(orderedLoan => orderedLoan.Account.BankUser)
                .SingleOrDefault(orderedLoan => orderedLoan.Id == id && 
                orderedLoan.Account.BankUserId != userId);
        }

        public IEnumerable<OrderLoan> GetSoldOrderLoans()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersLoans
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account.Currency)
                .Where(order => order.Account.BankUserId != userId)
                .Include(orderLoan => orderLoan.Account.Currency);
        }
    }
}
