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

        //public IActionResult AllCategories()
        //{
        //    return View();
        //}

        //public IActionResult AllProducts()
        //{
        //    return View();
        //}

        public IActionResult LoanAll()
        {
            var loanFromDb = this.context.Loans
                .Include(curency => curency.Curency)
                .ToList();

            var view = loanFromDb.Select(loan => new LoanAllViewModel
            {
                Id = loan.Id,
                Name = loan.Name,
                Amount = loan.Amount,
                Curency = loan.Curency.IsoCode,
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
                .Include(curency => curency.Curency)
                .Include(user => user.Seller)
                .SingleOrDefault();

            LoanDetailViewModel viewModel = new LoanDetailViewModel()
            {
                Id = loan.Id,
                Amount = loan.Amount,
                InterestRate = loan.InterestRate,
                Name = loan.Name,
                Period = loan.Period,
                CurencyIso = loan.Curency.IsoCode,
                CurencyName = loan.Curency.Name,
                Commission = loan.Commission, //TODO: implement this in sales
                Seller = loan.Seller.Name
            };


            return this.View(viewModel);
        }
    }
}