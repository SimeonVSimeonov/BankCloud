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
            List<Product> loanFromDb = this.context.Products
                .Where(product => product.GetType().Name == "Loan" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency)
                .ToList();

            var view = loanFromDb.Select(loan => new ProductsLoansViewModel
            {
                Id = loan.Id,
                Name = loan.Name,
                Amount = loan.Amount,
                Currency = loan.Account.Currency.IsoCode,
                InterestRate = loan.InterestRate,
                Period = loan.Period,
            });

            return View(view);
        }

        [HttpGet("/Products/LoanDetails/{id}")]
        public IActionResult LoanDetails(string id)
        {
            Product loanFromDb = this.context.Products
                .Where(loan => loan.Id == id)
                .Include(loan => loan.Account.Currency)
                .Include(loan => loan.Seller)
                .SingleOrDefault();

            ProductsLoanDetailsViewModel viewModel = new ProductsLoanDetailsViewModel()
            {
                Id = loanFromDb.Id,
                Amount = loanFromDb.Amount,
                InterestRate = loanFromDb.InterestRate,
                Name = loanFromDb.Name,
                Period = loanFromDb.Period,
                CurrencyIso = loanFromDb.Account.Currency.IsoCode,
                CurrencyName = loanFromDb.Account.Currency.Name,
                Commission = loanFromDb.Commission,
                Seller = loanFromDb.Seller.Name,
                SellerEmail = loanFromDb.Seller.Email
            };


            return this.View(viewModel);
        }

    }
}