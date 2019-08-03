using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Common;
using BankCloud.Services.Interfaces;
using FixerSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Web.Controllers
{
    public class CreditScoringsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrdersService ordersService;

        public CreditScoringsController(IOrdersService ordersService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IActionResult MySells()
        {
            return View();
        }

        public IActionResult PendingRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Pending);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        public IActionResult ApprovedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Approved);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        public IActionResult RejectedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Rejected);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [HttpGet("/CreditScorings/DetailRequest/{id}")]
        public IActionResult LoanDetailRequest(string id)
        {
            Order orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            var view = this.mapper.Map<Order, CreditScoringsOrderedLoanDetailViewModel>(orderedLoanFromDb);

            return View(view);
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
            OrderLoan orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            this.ordersService.RejectRequest(orderedLoanFromDb);

            return Redirect("/CreditScorings/PendingRequests");
        }
    }
}