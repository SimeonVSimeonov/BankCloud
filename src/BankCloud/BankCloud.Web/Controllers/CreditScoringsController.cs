using System;
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
using BankCloud.Services.Common;
using FixerSharp;
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
            //var orderedLoansFromDb = this.context.Orders
            //    .Include(ol => ol.Loan)
            //    .ThenInclude(oc => oc.Account.Currency)
            //    .Include(ol => ol.Account.BankUser)
            //    .Where(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
            //            && ol.Status == OrderStatus.Pending)
            //    .OrderByDescending(od => od.IssuedOn)
            //    .ToList();

            //var requestView = orderedLoansFromDb.Select(order => new CreditScoringsOrderedLoansViewModel
            //{
            //    Name = order.Name,
            //    Amount = order.Amount,
            //    Buyer = order.Account.BankUser.Name,
            //    Period = order.Period,
            //    MonthlyFee = order.MonthlyFee,
            //    Commission = order.CostPrice,
            //    Currency = order.Loan.Account.Currency.IsoCode,
            //    Id = order.Id,
            //});

           // return View(requestView);

            return View();
        }

        public IActionResult ApprovedRequests()
        {
            //var orderedLoansFromDb = this.context.Orders
            //    .Include(ol => ol.Loan)
            //    .ThenInclude(oc => oc.Account.Currency)
            //    .Include(ol => ol.Account.BankUser)
            //    .Where(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
            //            && ol.Status == OrderStatus.Approved)
            //    .OrderByDescending(od => od.IssuedOn)
            //    .ToList();

            //var requestView = orderedLoansFromDb.Select(order => new CreditScoringsOrderedLoansViewModel
            //{
            //    Name = order.Name,
            //    Amount = order.Amount,
            //    Buyer = order.Account.BankUser.Name,
            //    Period = order.Period,
            //    MonthlyFee = order.MonthlyFee,
            //    Commission = order.CostPrice,
            //    Currency = order.Loan.Account.Currency.IsoCode,
            //    Id = order.Id,
            //});

            //return View(requestView);
            return View();
        }

        public IActionResult RejectedRequests()
        {
            //var orderedLoansFromDb = this.context.Orders
            //    .Include(ol => ol.Loan)
            //    .ThenInclude(oc => oc.Account.Currency)
            //    .Include(ol => ol.Account.BankUser)
            //    .Where(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
            //            && ol.Status == OrderStatus.Rejected)
            //    .OrderByDescending(od => od.IssuedOn)
            //    .ToList();

            //var requestView = orderedLoansFromDb.Select(order => new CreditScoringsOrderedLoansViewModel
            //{
            //    Name = order.Name,
            //    Amount = order.Amount,
            //    Buyer = order.Account.BankUser.Name,
            //    Period = order.Period,
            //    MonthlyFee = order.MonthlyFee,
            //    Commission = order.CostPrice,
            //    Currency = order.Loan.Account.Currency.IsoCode,
            //    Id = order.Id,
            //});

            //return View(requestView);

            return View();
        }

        [HttpGet("/CreditScorings/DetailRequest/{id}")]
        public IActionResult LoanDetailRequest(string id)
        {
            //Order orderedLoanFromDb = this.context.Orders
            //    .Include(orderedLoan => orderedLoan.Account.BankUser)
            //    .ThenInclude(buyer => buyer.Accounts)
            //    .ThenInclude(loan => loan.Currency)
            //    .Include(orderedLoan => orderedLoan.Account.BankUser)
            //    .SingleOrDefault(orderedLoan => orderedLoan.Id == id);

            //List<Account> buyerAccounts = orderedLoanFromDb.Account.BankUser.Accounts.ToList();

            //var requestView = new CreditScoringsOrderedLoanDetailViewModel()
            //{
            //    Name = orderedLoanFromDb.Name,
            //    Amount = orderedLoanFromDb.Amount,
            //    Status = orderedLoanFromDb.Status.ToString(),
            //    Buyer = orderedLoanFromDb.Account.BankUser.Name,
            //    BuyerAcconts = buyerAccounts.Select(account => new UsersAccountViewModel()
            //    {
            //        Balance = account.Balance,
            //        IBAN = account.IBAN,
            //        MonthlyIncome = account.MonthlyIncome,
            //        MonthlyOutCome = account.MonthlyOutcome,
            //        CurrencyIso = account.Currency.IsoCode,
            //        CurrencyName = account.Currency.Name
            //    }),
            //    Period = orderedLoanFromDb.Period,
            //    IssuedOn = orderedLoanFromDb.IssuedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
            //    CompletedOn = orderedLoanFromDb.CompletedOn?.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
            //    MonthlyFee = orderedLoanFromDb.MonthlyFee,
            //    Commission = orderedLoanFromDb.CostPrice,
            //    Currency = orderedLoanFromDb.Account.Currency.IsoCode,
            //    CurrencyName = orderedLoanFromDb.Account.Currency.Name,
            //    InterestRate = orderedLoanFromDb.InterestRate,
            //    Id = orderedLoanFromDb.Id,
            //    AccountForTransfer = orderedLoanFromDb.Account.IBAN + " | " + orderedLoanFromDb.Account.Currency.IsoCode,
            //};

            // return View(requestView);
            return View();
        }

        [HttpGet("/CreditScorings/ApproveRequest/{id}")]
        public IActionResult ApproveRequest(string id)
        {

            //Order orderedLoanFromDb = this.context.Orders
            //    .Include(orderLoan => orderLoan.Account)
            //    .ThenInclude(orderedLoanAccount => orderedLoanAccount.Currency)
            //    .SingleOrDefault(ol => ol.Account.BankUser.IdentityNumber == User.FindFirst(ClaimTypes.NameIdentifier).Value
            //            && ol.Id == id);

            //Account buyerAccount = orderedLoanFromDb.Account;
            //Account sellerAccount = orderedLoanFromDb.Loan.Account;

            //if (sellerAccount.Balance < orderedLoanFromDb.Amount)
            //{
            //    this.TempData["error"] = GlobalConstants.ERROR_MESSAGE_FOR_INSUFFICIENT_FUNDS;

            //    return this.Redirect("/Users/Accounts");
            //}

            //double orderCost = (double)orderedLoanFromDb.CostPrice;
            //double orderAmount = (double)orderedLoanFromDb.Amount;
            //double orderFee = (double)orderedLoanFromDb.MonthlyFee;

            //if (buyerAccount.Currency.IsoCode != sellerAccount.Currency.IsoCode)
            //{
            //    ExchangeRate rateUsdGbp = Fixer
            //        .Rate(sellerAccount.Currency.IsoCode, buyerAccount.Currency.IsoCode);

            //    orderCost = rateUsdGbp.Convert(orderCost);
            //    orderAmount = rateUsdGbp.Convert(orderAmount);
            //    orderFee = rateUsdGbp.Convert(orderFee);
            //}

            //buyerAccount.Balance -= (decimal)orderCost;
            //buyerAccount.Balance += (decimal)orderAmount;
            //buyerAccount.MonthlyOutcome += (decimal)orderFee;

            //sellerAccount.Balance += orderedLoanFromDb.CostPrice;
            //sellerAccount.Balance -= orderedLoanFromDb.Amount;
            //sellerAccount.MonthlyIncome += orderedLoanFromDb.MonthlyFee;
            ////TODO: evry m trasfer
            //orderedLoanFromDb.CompletedOn = DateTime.UtcNow;
            //orderedLoanFromDb.Status = OrderStatus.Approved;

            //this.context.SaveChanges();

            return Redirect("/CreditScorings/PendingRequests");
        }

        [HttpGet("/CreditScorings/RejectRequest/{id}")]
        public IActionResult RejectRequest(string id)
        {
            //OrderLoan orderedLoanFromDb = this.context.Orders
            //     .Include(orderLoan => orderLoan.Account)
            //     .ThenInclude(orderedLoanAccount => orderedLoanAccount.Currency)
            //     .Include(orderLoan => orderLoan.Loan)
            //     .ThenInclude(loan => loan.Account)
            //     .ThenInclude(loanAccount => loanAccount.Currency)
            //     .SingleOrDefault(ol => ol.Loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
            //             && ol.Id == id);

            //orderedLoanFromDb.CompletedOn = DateTime.UtcNow;
            //orderedLoanFromDb.Status = OrderStatus.Rejected;

            //this.context.SaveChanges();

            return Redirect("/CreditScorings/PendingRequests");
        }
    }
}