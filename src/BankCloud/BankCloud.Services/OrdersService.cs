using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Services.Interfaces;
using FixerSharp;
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

        public void ApproveRequest(OrderLoan orderLoan)
        {
            Account buyerAccount = orderLoan.Account;
            Account sellerAccount = orderLoan.Loan.Account;

            double orderCost = (double)orderLoan.Commission;
            double orderAmount = (double)orderLoan.Amount;
            double orderFee = (double)orderLoan.MonthlyFee;

            if (buyerAccount.Currency.IsoCode != sellerAccount.Currency.IsoCode)
            {
                ExchangeRate rateUsdGbp = Fixer
                    .Rate(sellerAccount.Currency.IsoCode, buyerAccount.Currency.IsoCode);

                orderCost = rateUsdGbp.Convert(orderCost);
                orderAmount = rateUsdGbp.Convert(orderAmount);
                orderFee = rateUsdGbp.Convert(orderFee);
            }

            buyerAccount.Balance -= (decimal)orderCost;
            buyerAccount.Balance += (decimal)orderAmount;
            buyerAccount.MonthlyOutcome += (decimal)orderFee;

            sellerAccount.Balance += orderLoan.Commission;
            sellerAccount.Balance -= orderLoan.Amount;
            sellerAccount.MonthlyIncome += orderLoan.MonthlyFee;
            //TODO: evry mounts task trasfer
            orderLoan.CompletedOn = DateTime.UtcNow;
            orderLoan.Status = OrderStatus.Approved;

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
                .Include(orderedLoan => orderedLoan.Loan)
                .ThenInclude(loan => loan.Account)
                .ThenInclude(loan => loan.BankUser)
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
