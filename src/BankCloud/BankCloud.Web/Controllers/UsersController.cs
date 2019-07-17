using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly BankCloudDbContext context;
        private readonly UserManager<BankUser> userManager;

        public UsersController(BankCloudDbContext context,
            UserManager<BankUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        //[HttpGet("/Users/Products/{id}")]
        public IActionResult Products(string id)
        {
           //var ids = this.context.OrderLoans.Select(loanFromDb => loanFromDb.Id == id);

            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        
        public IActionResult AllMyLoans(MyOrderedLoansViewModel model)
        {
            List<OrderLoans> AllOrderLoansFormDb = this.context
                .OrderLoans
                .Include(x => x.Loan)
                .Where(loanFromDb => loanFromDb.ContractorId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .ToList();

            var viewAllOrderLoans = AllOrderLoansFormDb
                .Select(loanFromDb => new MyOrderedLoansViewModel
                {
                    Amount = loanFromDb.Amount,
                    MonthlyFee = loanFromDb.MonthlyFee,
                    Period = loanFromDb.Period,
                    Name = loanFromDb.Loan.Name,
                    Id = loanFromDb.Id,
                    Status = loanFromDb.Status.ToString()
                });

            return View(viewAllOrderLoans);
        }

        [HttpGet("/Users/MyLoan/{id}")]
        public IActionResult MyLoan(string id)
        {
            OrderLoans orderLoan = this.context
                .OrderLoans
                .Include(x => x.Loan)
                .ThenInclude(s => s.Seller)
                .SingleOrDefault(loan => loan.Id == id);

            var detailOrderLoan = new MyOrderedLoansDetailViewModel()
            {
                Name = orderLoan.Name,
                Period = orderLoan.Period,
                Amount = orderLoan.Amount,
                MonthlyFee = orderLoan.MonthlyFee,
                Commission = orderLoan.CostPrice,
                Seller = orderLoan.Loan.Seller.Name,
                InterestRate = orderLoan.InterestRate,
                IssuedOn = orderLoan.IssuedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                Status = orderLoan.Status.ToString(),
                CompletedOn = orderLoan.CompletedOn.ToString(),
            };

            return View(detailOrderLoan);
        }
    }
}