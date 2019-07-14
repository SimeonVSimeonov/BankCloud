using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult LoanOrder(string id)
        {
            Loan loanFromDb = this.context.Loans.SingleOrDefault(loan => loan.Id == id);

            LoanOrderInputModel model = new LoanOrderInputModel()
            {
                Amount = loanFromDb.Amount,
                MonthlyFee = loanFromDb.Commission,
                Period = loanFromDb.Period,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult LoanOrder(LoanOrderInputModel model)
        {
            var loanFromDb = this.context.Loans.SingleOrDefault(loan => loan.Id == model.Id);

            var curencyFromDb = this.context.Curencies;

            var orderLoan = new OrderLoans()
            {
                ContractorId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                IssuedOn = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                CostPrice = loanFromDb.Commission * loanFromDb.Amount / 100,
                LoanId = loanFromDb.Id,
                Amount = model.Amount,
                Name = loanFromDb.Name,
                InterestRate = loanFromDb.InterestRate,
                Period = model.Period,
                MonthlyFee = (model.Amount / model.Period) * ((loanFromDb.InterestRate / 100) + 1),
            };

            this.context.OrderLoans.Add(orderLoan);

            this.context.SaveChanges();

            return this.Redirect("/Products/LoanAll");
        }
    }
}