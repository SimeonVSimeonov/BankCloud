using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BankCloudDbContext context;

        public ProductsController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Loans()
        {
            var loanFromDb = this.context.Loans
                .Include(curency => curency.Account.Curency)
                .ToList();

            var view = loanFromDb.Select(loan => new ProductsLoansViewModel
            {
                Id = loan.Id,
                Name = loan.Name,
                Amount = loan.Amount,
                Curency = loan.Account.Curency.IsoCode,
                InterestRate = loan.InterestRate,
                Period = loan.Period,
            });

            return View(view);
        }

        [HttpGet("/Products/LoanDetails/{id}")]
        public IActionResult LoanDetails(string id)
        {
            Loan loan = this.context.Loans
                .Where(loanFromDb => loanFromDb.Id == id)
                .Include(curency => curency.Account.Curency)
                .Include(user => user.Seller)
                .SingleOrDefault();

            ProductsLoanDetailsViewModel viewModel = new ProductsLoanDetailsViewModel()
            {
                Id = loan.Id,
                Amount = loan.Amount,
                InterestRate = loan.InterestRate,
                Name = loan.Name,
                Period = loan.Period,
                CurencyIso = loan.Account.Curency.IsoCode,
                CurencyName = loan.Account.Curency.Name,
                Commission = loan.Commission, //TODO: implement this in sales
                Seller = loan.Seller.Name,
                SellerEmail = loan.Seller.Email
            };


            return this.View(viewModel);
        }

        public async Task<IActionResult> LoanDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loan loanFromDb = await this.context.Loans
                .Where(loan => loan.Id == id)
                .Include(curency => curency.Account.Curency)
                .Include(user => user.Seller)
                .SingleOrDefaultAsync();

            if (loanFromDb == null)
            {
                return NotFound();
            }

            var view = new ProductsLoanDetailsViewModel()
            {
                Id = loanFromDb.Id,
                Name = loanFromDb.Name,
                Amount = loanFromDb.Amount,
                InterestRate = loanFromDb.InterestRate,
                Commission = loanFromDb.Commission,
                Period = loanFromDb.Period,
                CurencyIso = loanFromDb.Account.Curency.IsoCode,
                CurencyName = loanFromDb.Account.Curency.Name,
            };

            return View(view);
        }

        [HttpPost, ActionName("LoanDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoanDeleteConfirmed(string id)
        {
            Loan loan = await this.context.Loans.FindAsync(id);
            this.context.Loans.Remove(loan);
            await this.context.SaveChangesAsync();
            return Redirect("/Products/Loans");
        }
    }
}