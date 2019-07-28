using System;
using System.Linq;
using System.Security.Claims;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BankCloudDbContext context;

        public OrdersController(BankCloudDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/Orders/OrderLoan/{id}")]
        [Authorize]
        public IActionResult OrderLoan(string id)
        {
            Loan loanFromDb = this.context.Loans
                .Include(loan => loan.Account)
                .ThenInclude(account => account.Currency)
                .SingleOrDefault(loan => loan.Id == id);

            BankUser userFromDb = this.context.Users
                .Include(user => user.Accounts)
                .ThenInclude(account => account.Currency)
                .SingleOrDefault(user => user.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Accounts"] = userFromDb.Accounts.ToList();

            OrdersOrderLoanInputModel model = new OrdersOrderLoanInputModel()
            {
                Name = loanFromDb.Name,
                Amount = loanFromDb.Amount,
                Period = loanFromDb.Period,
                InterestRate = loanFromDb.InterestRate,
                MonthlyFee = decimal
                .Round(((loanFromDb.Amount / loanFromDb.Period) * ((loanFromDb.InterestRate / 100) + 1)),
                                                                    2, MidpointRounding.AwayFromZero),
                CurrencyName = loanFromDb.Account.Currency.Name,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult OrderLoan(OrdersOrderLoanInputModel model)
        {
            decimal monthlyFee = 0m;

            Loan loanFromDb = this.context.Loans
                .Include(loan => loan.Account)
                .ThenInclude(account => account.Currency)
                .SingleOrDefault(loan => loan.Id == model.Id);

            BankUser userFromDb = this.context.Users
                 .Include(user => user.Accounts)
                 .ThenInclude(account => account.Currency)
                 .SingleOrDefault(user => user.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Accounts"] = userFromDb.Accounts.ToList();

            if (model.Period != 0)
            {
                monthlyFee = decimal
                  .Round(((model.Amount / model.Period) * ((loanFromDb.InterestRate / 100) + 1)),
                                                                      2, MidpointRounding.AwayFromZero);
            }


            var orderLoan = new OrderLoan()
            {
                BuyerId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                IssuedOn = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                CostPrice = loanFromDb.Commission * loanFromDb.Amount / 100,
                LoanId = loanFromDb.Id,
                Amount = model.Amount,
                Name = loanFromDb.Name,
                InterestRate = loanFromDb.InterestRate,
                Period = model.Period,
                MonthlyFee = monthlyFee,
                AccountId = model.AccountId,
            };

            //TODO: add message for invalid parameters

            if (!userFromDb.Accounts.Any())
            {
                return this.Redirect("/Users/AccountActivate");
            }

            if (!ModelState.IsValid || model.Amount > loanFromDb.Amount 
                || model.Period > loanFromDb.Period 
                || model.InterestRate != loanFromDb.InterestRate)
            {
                model.Name = loanFromDb.Name;
                //model.CurencyName = loanFromDb.Account.Curency.Name;
                return this.View(model);
            }

            this.context.OrderLoans.Add(orderLoan);

            this.context.SaveChanges();

            return this.Redirect("/Users/OrderedLoans");
        }
    }
}