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
using Microsoft.EntityFrameworkCore;

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
            this.ViewData["Accounts"] = this.context.Accounts
                .Include(account => account.Currency)
                .Where(accoun => accoun.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult LoanSell(SellsLoanInputModel model)
        {
            this.ViewData["Accounts"] = this.context.Accounts
                .Include(account => account.Currency)
                .Where(accoun => accoun.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .ToList();

            var userAccountIds = this.context.Accounts
                .Where(account => account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .Select(account => account.Id)
                .ToList();

            if (!userAccountIds.Contains(model.AccountId))
            {
                //TODO: check if need this?
                return this.Redirect("/Sells/LoanSell");
            }

            Product loan = new Loan
            {

                Amount = model.Amount,
                InterestRate = model.InterestRate,
                SellerID = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Period = model.Period,
                Name = model.Name,
                AccountId = model.AccountId,
                Commission = model.Commission,
            };

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            context.Products.Add(loan);
            context.SaveChanges();

            return Redirect("/Products/Loans");
        }
    }
}