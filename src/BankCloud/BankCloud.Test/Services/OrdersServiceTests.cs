using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Services;
using BankCloud.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace BankCloud.Test.Services
{
    public class OrdersServiceTests
    {
        [Fact]
        public void AddOrderLoanShouldAddOrderLoan()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_OrderLoan_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var product = new Loan
            {
                Name = "ABCD",
                Amount = 1000m,
                Commission = 0.1m,
                InterestRate = 10m,
                Period = 12
            };
            var order = new OrderLoan
            {
                Name = product.Name,
                Commission = BankCloudCalculator.CalculateCommission(product),
                MonthlyFee = BankCloudCalculator.CalculateMounthlyFee(product)
            };
            ordersService.AddOrderLoan(order, product);
            dbContext.SaveChanges();

            var orders = dbContext.OrdersLoans.ToList();

            Assert.Single(orders);
            Assert.Equal(order.Name, orders.First().Name);

        }

        [Fact]
        public void AddOrderSaveShouldAddOrderSave()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_OrderSave_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var product = new Save
            {
                Name = "ABCD",
                Amount = 1000m,
                Commission = 0,
                InterestRate = 10m,
                Period = 12
            };
            var order = new OrderSave
            {
                Name = product.Name,
            };
            order.MonthlyFee = BankCloudCalculator.CalculateDepositMonthlyIncome(order, product);
            ordersService.AddOrderSave(order, product);
            dbContext.SaveChanges();

            var orders = dbContext.OrdersSaves.ToList();

            Assert.Single(orders);
            Assert.Equal(order.Name, orders.First().Name);

        }

        [Fact]
        public void RejectRequestShouldSetOrderRajected()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "RejectReques_Order_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var orderId = "abcd123";
            var product = new Save
            {
                Name = "ABCD",
                Amount = 1000m,
                Commission = 0,
                InterestRate = 10m,
                Period = 12
            };
            var order = new OrderSave
            {
                Id = orderId,
                Name = product.Name,
            };

            ordersService.AddOrderSave(order, product);
            dbContext.SaveChanges();

            var ordered = dbContext.OrdersSaves.Find(orderId);
            ordersService.RejectRequest(ordered);
            dbContext.SaveChanges();
            var rejected = dbContext.OrdersSaves.Find(orderId);

            Assert.Equal(OrderStatus.Rejected, rejected.Status);
        }

        [Fact]
        public void ApproveLoanRequestSholudSetOrderLoanToApprove()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
               .UseInMemoryDatabase(databaseName: "Approve_OrderLoan_Database")
               .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var orderId = "abcd123";
            var product = new Loan
            {
                Name = "ABCD",
                Amount = 1000m,
                Commission = 0.1m,
                InterestRate = 10m,
                Period = 12,
                Account = new Account { Currency = new Currency { IsoCode = "USD" } }
            };
            var order = new OrderLoan
            {
                Id = orderId,
                Name = product.Name,
                Account = new Account { Currency = new Currency { IsoCode = "USD" } },
                Commission = BankCloudCalculator.CalculateCommission(product),
                MonthlyFee = BankCloudCalculator.CalculateMounthlyFee(product),
                Loan = product
            };
            dbContext.OrdersLoans.Add(order);
            dbContext.SaveChanges();

            var ordered = dbContext.OrdersLoans.Find(orderId);

            ordersService.ApproveLoanRequest(ordered);
            dbContext.SaveChanges();

            var approved = dbContext.OrdersLoans.Find(orderId);

            Assert.Equal(OrderStatus.Approved, approved.Status);
        }

        [Fact]
        public void ApproveSaveRequestSholudSetOrderSaveToApprove()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Approve_OrderSave_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var orderId = "abcd123";
            var product = new Save
            {
                Name = "ABCD",
                Amount = 1000m,
                Commission = 0,
                InterestRate = 10m,
                Period = 12,
                Account = new Account { Currency = new Currency { IsoCode = "USD"} }
            };
            var order = new OrderSave
            {
                Id = orderId,
                Name = product.Name,
                Save = product,
                Account = new Account { Currency = new Currency { IsoCode = "USD" } }
            };
            order.MonthlyFee = BankCloudCalculator.CalculateDepositMonthlyIncome(order, product);
            dbContext.OrdersSaves.Add(order);
            dbContext.SaveChanges();

            var ordered = dbContext.OrdersSaves.Find(orderId);

            ordersService.ApproveSaveRequest(ordered);
            dbContext.SaveChanges();

            var approved = dbContext.OrdersSaves.Find(orderId);

            Assert.Equal(OrderStatus.Approved, approved.Status);
        }

        [Fact]
        public void GetOrderByIdShouldReturnCorrectOrder()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderById_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var ordersService = new OrdersService(dbContext, null);

            var orderId = "123abc";
            var order = new OrderLoan { Id = orderId };
            dbContext.OrdersLoans.Add(order);
            dbContext.SaveChanges();

            var returnedOrder = ordersService.GetOrderById(orderId);

            Assert.Equal(order, returnedOrder);
        }


    }
}
