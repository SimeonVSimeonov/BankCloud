using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Common;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BankCloud.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly BankCloudDbContext context;
        private readonly IMapper mapper;
        private readonly IOrdersService ordersService;

        public UsersController(BankCloudDbContext context,
            IOrdersService ordersService, IMapper mapper)
        {
            this.context = context;
            this.ordersService = ordersService;
            this.mapper = mapper;
        }

        public IActionResult Products(string id)
        {
            return View();
        }



        public IActionResult ProductLoans()
        {
            List<Product> loanFromDb = this.context.Products
                .Where(product => product.GetType().Name == "Loan")
                .Include(loan => loan.Account.Currency)
                .Where(loan => loan.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
                && loan.IsDeleted == false)
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

        [HttpGet("/Users/ProductLoanDetails/{id}")]
        public IActionResult ProductLoanDetails(string id)
        {
            Product loanFromDb = this.context.Products
               .Where(product => product.GetType().Name == "Loan" && product.Id == id)
               .Include(curency => curency.Account.Currency)
               .Include(user => user.Seller)
               .SingleOrDefault();

            var view = new ProductsLoanDetailsViewModel()
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


            return this.View(view);
        }

        public IActionResult LoanDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product loanFromDb = this.context.Products
               .Where(product => product.GetType().Name == "Loan" && product.Id == id)
               .Include(curency => curency.Account.Currency)
               .Include(user => user.Seller)
               .SingleOrDefault();

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
                CurrencyIso = loanFromDb.Account.Currency.IsoCode,
                CurrencyName = loanFromDb.Account.Currency.Name,
            };

            return View(view);
        }

        [HttpPost, ActionName("LoanDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult LoanDeleteConfirmed(string id)
        {
            Product loan = this.context.Products.Find(id);

            var pendingLoanIds = this.context.OrdersLoans
                .Where(orderedLoan => orderedLoan.Status == OrderStatus.Pending)
                .Select(orderedLoan => orderedLoan.Id);

            if (pendingLoanIds.Contains(loan.Id))
            {
                return this.Redirect("/CreditScorings/PendingRequests");
            }

            loan.IsDeleted = true;
            this.context.SaveChanges();
            return Redirect("/Users/ProductLoans");

        }

        public IActionResult ArchivedProductLoans()
        {
            List<Product> loanFromDb = this.context.Products
                .Include(product => product.Account.Currency)
                .Where(product => product.GetType().Name == "Loan" 
                && product.SellerID == User.FindFirst(ClaimTypes.NameIdentifier).Value
                && product.IsDeleted == true)
                .ToList();

            var view = loanFromDb.Select(loan => new ProductsLoansViewModel
            {
                Id = loan.Id,
                Name = loan.Name,
                Amount = loan.Amount,
                //Currency = loan.Account.Currency.IsoCode,
                InterestRate = loan.InterestRate,
                Period = loan.Period,
            });

            return View(view);
        }

        [HttpGet("/Users/RestoreProductloan/{id}")]
        public IActionResult RestoreProductloan(string id)
        {
            Product loanFromDb = this.context.Products
                .SingleOrDefault(loan => loan.Id == id);

            loanFromDb.IsDeleted = false;

            this.context.SaveChanges();

            return this.Redirect("/Users/ProductLoans");
        }

        public IActionResult OrderedLoans()
        {
            IEnumerable<OrderLoan> userOrderedLoanFromDB = this.ordersService.GetOrderedLoansByUser();

           var viewAllOrderLoans = this.mapper
                .Map<List<UsersOrderedLoansViewModel>>(userOrderedLoanFromDB);

            return View(viewAllOrderLoans);
        }

        [HttpGet("/Users/OrderedLoanDetails/{id}")]
        public IActionResult OrderedLoanDetails(string id)
        {
            OrderLoan userOrderedLoanFromDB = this.ordersService.GetOrderLoanById(id);

            var detailOrderLoan = this.mapper
                .Map<OrderedLoansDetailViewModel>(userOrderedLoanFromDB);

            detailOrderLoan.Account = userOrderedLoanFromDB.Account.IBAN + " | " + userOrderedLoanFromDB.Account.Currency.Name;
            detailOrderLoan.DueAmount = userOrderedLoanFromDB.MonthlyFee * userOrderedLoanFromDB.Period;

            return View(detailOrderLoan);

        }
    }
}