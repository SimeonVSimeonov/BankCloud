using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BankCloudDbContext context;

        public ProductsController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult AllCategories()
        {
            return View();
        }

        public IActionResult AllProducts()
        {
            return View();
        }

        public IActionResult LoanAll()
        {
            var loanFromDb = this.context.Loans.ToList();

            var view = loanFromDb.Select(x => new LoanAllViewModel { Id = x.Id, Name = x.Name });

            return View(view);
        }
    }
}