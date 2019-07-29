using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BankCloud.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly BankCloudDbContext context;

        public UsersController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Products(string id)
        {
            return View();
        }

        public IActionResult Accounts()
        {
            var userAccountsFromDb = this.context.Accounts
                .Where(account => account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);



            var viewAccounts = userAccountsFromDb.Select(accounts =>
            new UsersAccountViewModel
            {
                Id = accounts.Id,
                IBAN = accounts.IBAN,
                MonthlyIncome = accounts.MonthlyIncome,
                MonthlyOutCome = accounts.MonthlyOutcome,
                Balance = accounts.Balance,
                CurrencyName = accounts.Currency.Name,
                CurrencyIso = accounts.Currency.IsoCode
            });

            if (!userAccountsFromDb.Any())
            {
                return this.Redirect("/Users/AccountActivate");
            }
            else
            {
                return View(viewAccounts);
            }
        }

        public IActionResult AccountActivate()
        {
            var userAccountsFromDb = this.context.Accounts
               .Where(account => account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Curencies"] = this.context.Currencies.ToList();

            if (!userAccountsFromDb.Any())
            {
                return View();
            }
            else
            {
                return this.Redirect("/Users/Accounts");
            }
        }

        [HttpPost]
        public IActionResult AccountActivate(AccountActivateInputModel model)
        {
            var userFromDb = this.context.Users
                //.Include(a => a.Accounts)
                .SingleOrDefault(user => user.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            userFromDb.Middlename = model.Middlename;
            userFromDb.IdentityNumber = model.IdentityNumber;
            userFromDb.Surname = model.Surname;
            userFromDb.PhoneNumber = model.PhoneNumber;

            userFromDb.Address = new Address
            {
                Country = model.Address.Country,
                City = model.Address.City,
                Street = model.Address.Street
            };

            userFromDb.Accounts.Add(new Account
            {
                IBAN = IbanGenerator.Generate(),
                MonthlyIncome = model.Account.MonthlyIncome,
                CurrencyId = model.Account.Currency,
                Balance = model.Account.Charge,
            });

            this.context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult AccountCreate()
        {
            var userAccountsFromDb = this.context.Accounts
                .Where(account => account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Curencies"] = this.context.Currencies.ToList();

            if (!userAccountsFromDb.Any())
            {
                return this.Redirect("/Users/Accounts");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult AccountCreate(AccountInputModel model)
        {

            var userFromDb = this.context.Users.Include(a => a.Accounts)
                .SingleOrDefault(user => user.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            userFromDb.Accounts.Add(new Account
            {
                IBAN = IbanGenerator.Generate(),
                MonthlyIncome = model.MonthlyIncome,
                CurrencyId = model.Currency,
                Balance = model.Charge,
            });

            this.context.SaveChanges();
            return Redirect("/Users/Accounts");
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

            var pendingLoanIds = this.context.Orders
                .Where(orderedLoan => orderedLoan.Status == OrderStatus.Pending)
                .Select(orderedLoan => orderedLoan.Id);

            if (pendingLoanIds.Contains(loan.Id))
            {
                return this.Redirect("/CreditScorings/PendingRequests");
            }

            loan.IsDeleted = true;
            //this.context.Loans.Remove(loan);
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
                Currency = loan.Account.Currency.IsoCode,
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

        public IActionResult OrderedLoans(UsersOrderedLoansViewModel model)
        {
            List<Order> AllOrderLoansFormDb = this.context
                .Orders.Where(order => order.GetType().Name == "OrderLoan")
                //.Include(orderLoan => orderLoan.)
                .Include(orderLoan => orderLoan.Account.Currency)
                .Where(orderLoan => orderLoan.Account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                //&& orderLoan.LoanId != null)
                .ToList();

            var viewAllOrderLoans = AllOrderLoansFormDb
                .Select(loanFromDb => new UsersOrderedLoansViewModel
                {
                    Amount = loanFromDb.Amount,
                    MonthlyFee = loanFromDb.MonthlyFee,
                    Period = loanFromDb.Period,
                    Name = loanFromDb.Name,
                    Id = loanFromDb.Id,
                    Status = loanFromDb.Status.ToString(),
                    CurrencyIso = loanFromDb.Account.Currency.IsoCode
                });

            return View(viewAllOrderLoans);
        }

        [HttpGet("/Users/OrderedLoanDetails/{id}")]
        public IActionResult OrderedLoanDetails(string id)
        {
            Order orderLoanFromDB = this.context
                .Orders.Where(order => order.GetType().Name == "OrderLoan")
                .Include(orderLoan => orderLoan.Account)
                .ThenInclude(orderLoan => orderLoan.Currency)
                //.Include(orderLoan => orderLoan.Loan)
                .Include(orderLoan => orderLoan.Account)
                .ThenInclude(loan => loan.BankUser)
                .SingleOrDefault(orderLoan => orderLoan.Id == id);

            var detailOrderLoan = new MyOrderedLoansDetailViewModel()
            {
                Name = orderLoanFromDB.Name,
                Period = orderLoanFromDB.Period,
                Amount = orderLoanFromDB.Amount,
                MonthlyFee = orderLoanFromDB.MonthlyFee,
                Commission = orderLoanFromDB.CostPrice,
                Seller = orderLoanFromDB.Account.BankUser.Name,
                InterestRate = orderLoanFromDB.InterestRate,
                IssuedOn = orderLoanFromDB.IssuedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                Status = orderLoanFromDB.Status.ToString(),
                CompletedOn = orderLoanFromDB.CompletedOn.ToString(),
                //CurrencyIso = orderLoanFromDB.Loan.Account.Currency.IsoCode,
                DueAmount = orderLoanFromDB.MonthlyFee * orderLoanFromDB.Period,
                Account = orderLoanFromDB.Account.IBAN + " | " + orderLoanFromDB.Account.Currency.Name
            };

            return View(detailOrderLoan);
        }
    }
}