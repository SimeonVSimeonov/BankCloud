using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankCloud.Web.Models;
using BankCloud.Data.Context;
using BankCloud.Models.ViewModels;

namespace BankCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankCloudDbContext context;

        public HomeController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            int loansCount = this.context.Loans.Count();
            decimal loanWhitMaxAmount = this.context.Loans.Max(x => x.Amount);
            var maxLoanPeriod = this.context.Loans.Max(x => x.Period);
            var minLoanRate = this.context.Loans.Min(x => x.InterestRate);

            var loanViewCategories = new HomeCategoriesViewModel()
            {
                LoansCount = loansCount,
                MaxLoanAmount = loanWhitMaxAmount,
                MaxLoanPeriod = maxLoanPeriod,
                MinLoanRate = minLoanRate,
            };

            return View(loanViewCategories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
