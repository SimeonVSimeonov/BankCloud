using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        [HttpGet("/Orders/LoanOrder/{id}")]
        [Authorize]
        public IActionResult LoanOrder(string id)
        {
            Loan loanFromDb = this.context.Loans.SingleOrDefault(loan => loan.Id == id);

            BankUser user = this.context.Users
                .Include(u => u.Accounts)
                .ThenInclude(a => a.Curency)
                .SingleOrDefault(u => u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Accounts"] = user.Accounts.ToList();

            LoanOrderInputModel model = new LoanOrderInputModel()
            {
                Amount = loanFromDb.Amount,
                Period = loanFromDb.Period,
                InterestRate = loanFromDb.InterestRate,
                MonthlyFee = decimal
                .Round(((loanFromDb.Amount / loanFromDb.Period) * ((loanFromDb.InterestRate / 100) + 1)),
                                                                    2, MidpointRounding.AwayFromZero),
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult LoanOrder(LoanOrderInputModel model)
        {
            var loanFromDb = this.context.Loans.SingleOrDefault(loan => loan.Id == model.Id);
            BankUser user = this.context.Users.Include(u => u.Accounts)
                .SingleOrDefault(u => u.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

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
                MonthlyFee = decimal
                .Round(((model.Amount / model.Period) * ((loanFromDb.InterestRate / 100) + 1)),
                                                                    2, MidpointRounding.AwayFromZero),
                AccountId = model.AccountId
            };

            //TODO: add message for invalid parameters

            if (model.Amount > loanFromDb.Amount 
                || model.Period > loanFromDb.Period 
                || model.InterestRate != loanFromDb.InterestRate)
            {
                return this.RedirectToAction();
            }

            if (!user.Accounts.Any())
            {
                return this.Redirect("/Users/AccountActivate");
            }

            this.context.OrderLoans.Add(orderLoan);

            this.context.SaveChanges();

            return this.Redirect("/Users/AllMyLoans");
        }
    }
}