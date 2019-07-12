using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BankCloud.Models.ViewModels;

namespace BankCloud.Web.Controllers
{
    public class SellsController : Controller
    {
        private readonly BankCloudDbContext context;
        private readonly UserManager<BankUser> userManager;


        public SellsController(
            BankCloudDbContext context, 
            UserManager<BankUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult LoanSell()
        {
            this.ViewData["Curencies"] = this.context.Curencies.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult LoanSell(LoanSellInputModel model)
        {


            var loan = new Loan
            {

                Amount = model.Amount,
                InterestRate = model.InterestRate,
                BankUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Period = model.Period,
                Name = model.Name,
                Curency = context.Curencies.SingleOrDefault(curency => curency.Id == model.Curency)

            };

            context.Loans.Add(loan);
            context.SaveChanges();

            return Redirect("/Products/LoanAll");
        }

    }
}