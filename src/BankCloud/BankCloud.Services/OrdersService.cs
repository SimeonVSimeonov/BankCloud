﻿using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Services.Common;
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

        public void AddOrderLoan(OrderLoan order, Product loan)
        {
            if (order == null || loan == null)
            {
                return;
            }

            order.Commission = BankCloudCalculator.CalculateCommission(loan);
            order.MonthlyFee = BankCloudCalculator.CalculateMounthlyFee(loan);
            order.Status = OrderStatus.Pending;
            order.Name = loan.Name;
            loan.Popularity++;

            context.OrdersLoans.Add(order);
            context.SaveChanges();
        }

        public void AddOrderSave(OrderSave order, Product save)
        {
            if (order == null || save == null)
            {
                return;
            }

            order.MonthlyFee = BankCloudCalculator.CalculateDepositMonthlyIncome(order, save);
            order.Status = OrderStatus.Pending;
            order.Name = save.Name;
            save.Popularity++;

            context.OrdersSaves.Add(order);
            context.SaveChanges();
        }

        public void RejectRequest(Order ordered)
        {
            if (ordered == null)
            {
                return;
            }

            ordered.CompletedOn = DateTime.UtcNow;
            ordered.Status = OrderStatus.Rejected;

            this.context.SaveChanges();
        }

        public void ApproveLoanRequest(OrderLoan orderLoan)
        {
            Account buyerAccount = orderLoan.Account;
            Account sellerAccount = orderLoan.Loan.Account;

            double orderCost = (double)orderLoan.Commission;
            double orderAmount = (double)orderLoan.Amount;
            double orderFee = (double)orderLoan.MonthlyFee;

            if (buyerAccount.Currency.IsoCode != sellerAccount.Currency.IsoCode)
            {
                ExchangeRate rateFromTo = Fixer
                    .Rate(sellerAccount.Currency.IsoCode, buyerAccount.Currency.IsoCode);

                orderCost = rateFromTo.Convert(orderCost);
                orderAmount = rateFromTo.Convert(orderAmount);
                orderFee = rateFromTo.Convert(orderFee);
            }

            buyerAccount.Balance -= (decimal)orderCost;
            buyerAccount.Balance += (decimal)orderAmount;
            buyerAccount.MonthlyOutcome += (decimal)orderFee;

            sellerAccount.Balance += orderLoan.Commission;
            sellerAccount.Balance -= orderLoan.Amount;
            sellerAccount.MonthlyIncome += orderLoan.MonthlyFee;
            //TODO: every mounts task transfer
            orderLoan.CompletedOn = DateTime.UtcNow;
            orderLoan.Status = OrderStatus.Approved;

            this.context.SaveChanges();
        }

        public void ApproveSaveRequest(OrderSave orderedSave)
        {
            Account depositorAccount = orderedSave.Account;
            Account sellerAccount = orderedSave.Save.Account;

            double depositAmount = (double)orderedSave.Amount;
            double monthlyIncome = (double)orderedSave.MonthlyFee;

            if (depositorAccount.Currency.IsoCode != sellerAccount.Currency.IsoCode)
            {
                ExchangeRate rateFromTo = Fixer
                    .Rate(sellerAccount.Currency.IsoCode, depositorAccount.Currency.IsoCode);

                depositAmount = rateFromTo.Convert(depositAmount);
                monthlyIncome = rateFromTo.Convert(monthlyIncome);

            }

            depositorAccount.Balance -= (decimal)depositAmount;
            depositorAccount.MonthlyIncome += (decimal)monthlyIncome;
            //TODO every mounts task transfer
            sellerAccount.Balance += orderedSave.Amount;
            sellerAccount.MonthlyOutcome += orderedSave.MonthlyFee;

            orderedSave.CompletedOn = DateTime.UtcNow;
            orderedSave.Status = OrderStatus.Approved;

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

        public IEnumerable<string> GetAgentOrderSavesIds()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersSaves
                .Where(orderedSave => orderedSave.Status == OrderStatus.Pending &&
                    orderedSave.Account.BankUserId == userId)
                .Select(orderedSave => orderedSave.Id);
        }

        public Order GetOrderById(string id)
        {
           return this.context.Find<Order>(id);
        }

        public IEnumerable<Order> GetAllOrderedByCurrentUser()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            IEnumerable<Order> orderedSaves = this.context.OrdersSaves
                .Where(x => x.Account.BankUserId == userId);

            IEnumerable<Order> orderedLoans = this.context.OrdersLoans
                .Where(x => x.Account.BankUserId == userId);

            var result = orderedSaves.Concat(orderedLoans);
            //TODO add insurance and Invetsment
            return result;
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
        public IEnumerable<OrderSave> GetOrderedSavesByCurrentUser()
        {
            string userId = httpContextAccessor.HttpContext.User
               .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersSaves
                .Include(orderSave => orderSave.Save)
                .ThenInclude(save => save.Account.Currency)
                .Where(order => order.Account.BankUserId == userId)
                .Include(orderSave => orderSave.Account.Currency);
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
        public OrderSave GetOrderSaveById(string id)
        {
            return this.context.OrdersSaves
                .Include(orderSave => orderSave.Account)
                .ThenInclude(account => account.Currency)
                .Include(orderSave => orderSave.Save)
                .ThenInclude(save => save.Account)
                .ThenInclude(account => account.Currency)
                .Include(orderSave => orderSave.Save.Account.BankUser)
                .SingleOrDefault(orderSave => orderSave.Id == id);
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
        public OrderSave GetSoldOrderSaveById(string id)
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersSaves
                .Include(orderedSave => orderedSave.Account.BankUser)
                .ThenInclude(buyer => buyer.Accounts)
                .ThenInclude(save => save.Currency)
                .Include(orderedSave => orderedSave.Save)
                .ThenInclude(save => save.Account)
                .ThenInclude(save => save.BankUser)
                .SingleOrDefault(orderedSave => orderedSave.Id == id &&
                orderedSave.Account.BankUserId != userId);
        }

        public IEnumerable<OrderLoan> GetSoldOrderLoans()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersLoans
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account.Currency)
                .Where(order => order.Account.BankUserId != userId
                && order.Loan.Account.BankUserId == userId)
                .Include(orderLoan => orderLoan.Account.Currency);
        }

        public IEnumerable<OrderSave> GetSoldOrderSaves()
        {
            string userId = httpContextAccessor.HttpContext.User
                 .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.OrdersSaves
                .Include(orderSave => orderSave.Save)
                .ThenInclude(save => save.Account.Currency)
                .Where(order => order.Account.BankUserId != userId
                    && order.Save.Account.BankUserId == userId)
                .Include(orderSave => orderSave.Account.Currency);
        }
    }
}
