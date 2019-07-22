﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Web.Controllers
{
    public class CreditScoringsController : Controller
    {
        private readonly BankCloudDbContext context;

        public CreditScoringsController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult MySells()
        {
            return View();
        }

        public IActionResult PendingRequests()
        {
            var orderedLoansFromDb = this.context.OrderLoans
                .Include(ol => ol.Loan)
                .ThenInclude(oc => oc.Curency)
                .Include(ol => ol.Buyer)
                .Where(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        && ol.Status == OrderStatus.Pending)
                .OrderByDescending(od => od.IssuedOn)
                .ToList();

            var requestView = orderedLoansFromDb.Select(order => new CreditScoringsOrderedLoansViewModel
            {
                Name = order.Name,
                Amount = order.Amount,
                Buyer = order.Buyer.Name,
                Period = order.Period,
                MonthlyFee = order.MonthlyFee,
                Commission = order.CostPrice,
                Curency = order.Loan.Curency.IsoCode,
                Id = order.Id,
            });

            return View(requestView);
        }

        [HttpGet("/CreditScorings/DetailRequest/{id}")]
        public IActionResult LoanDetailRequest(string id)
        {
            OrderLoan orderedLoanFromDb = this.context.OrderLoans
                .Include(orderedLoan => orderedLoan.Buyer)
                .ThenInclude(buyer => buyer.Accounts)
                .ThenInclude(loan => loan.Curency)
                .Include(orderedLoan => orderedLoan.Loan)
                .SingleOrDefault(orderedLoan => orderedLoan.Id == id);


            var buyerAccounts = orderedLoanFromDb.Buyer.Accounts.ToList();

            var requestView = new CreditScoringsOrderedLoanDetailViewModel()
            {
                Name = orderedLoanFromDb.Name,
                Amount = orderedLoanFromDb.Amount,
                Status = orderedLoanFromDb.Status.ToString(),
                Buyer = orderedLoanFromDb.Buyer.Name,
                BuyerAcconts = buyerAccounts.Select(account => new UsersAccountViewModel()
                {
                    Balance = account.Balance,
                    IBAN = account.IBAN,
                    MonthlyIncome = account.MonthlyIncome,
                    MonthlyOutCome = account.MonthlyOutcome,
                    CurencyIso = account.Curency.IsoCode,
                    //CurencyName = account.Curency.Name
                }),
                Period = orderedLoanFromDb.Period,
                IssuedOn = orderedLoanFromDb.IssuedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                CompletedOn = orderedLoanFromDb.CompletedOn?.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                MonthlyFee = orderedLoanFromDb.MonthlyFee,
                Commission = orderedLoanFromDb.CostPrice,
                Curency = orderedLoanFromDb.Loan.Curency.IsoCode,
                InterestRate = orderedLoanFromDb.InterestRate,
                Id = orderedLoanFromDb.Id,
            };
            
            return View(requestView);
        }

        [HttpGet("/CreditScorings/ApproveRequest/{id}")]
        public IActionResult ApproveRequest(string id)
        {
            OrderLoan orderedLoanFromDb = this.context.OrderLoans
                .Include(order => order.Account)
                .SingleOrDefault(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
                        && ol.Id == id);

            var userAccFromDb = this.context.Users
                .Include(user => user.Accounts)
                .Where(user => user.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .SelectMany(accounts => accounts.Accounts
                .Where(account => account.CurencyId == orderedLoanFromDb.Account.CurencyId))
                .ToList();
                

            ;
            orderedLoanFromDb.CompletedOn = DateTime.UtcNow;
            orderedLoanFromDb.Status = OrderStatus.Approved;

            orderedLoanFromDb.Account.Balance -= orderedLoanFromDb.CostPrice;
            orderedLoanFromDb.Account.Balance += orderedLoanFromDb.Amount;



            //this.context.SaveChanges();

            return Redirect("/CreditScorings/PendingRequests");
        }
    }
}