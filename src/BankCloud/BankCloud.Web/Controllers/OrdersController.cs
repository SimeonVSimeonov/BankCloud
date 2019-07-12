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
            Loan loan = this.context.Loans.SingleOrDefault(loanFromDb => loanFromDb.Id == id);

            LoanOrderInputModel model = new LoanOrderInputModel()
            {
                Amount = loan.Amount,
                Installment = loan.InterestRate,
                Period = loan.Period  
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult LoanOrder(LoanOrderInputModel model)
        {




            return this.Redirect("/Products/MyProducts");
        }
    }
}