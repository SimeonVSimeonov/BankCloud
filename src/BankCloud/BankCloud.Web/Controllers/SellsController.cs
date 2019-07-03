using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class SellsController : Controller
    {
        private readonly BankCloudDbContext context;

        public SellsController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Loan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loan(LoanSellInputModel model)
        {
            var loan = new Loan
            {
                Amount = model.Amount,
                InterestRate = model.InterestRate,
                Period = model.Period,
                Name = model.Name,
                MonthlyFee = model.MonthlyFee,

            };

            context.Loans.Add(loan);
            context.SaveChanges();

            return Redirect("/Products/LoanAll");
        }

    }
}