using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using BankCloud.Data.Entities;
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
        private readonly UserManager<BankUser> userManager;

        public UsersController(BankCloudDbContext context,
            UserManager<BankUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
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
                IBAN = accounts.IBAN,
                MonthlyIncome = accounts.MonthlyIncome,
                Balance = accounts.Balance,
                CurencyName = accounts.Curency.Name,
                CurencyIso = accounts.Curency.IsoCode
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

            this.ViewData["Curencies"] = this.context.Curencies.ToList();

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
                CurencyId = model.Account.Curency,
                Balance = model.Account.Charge,
            });

            this.context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult AccountCreate()
        {
            var userAccountsFromDb = this.context.Accounts
                .Where(account => account.BankUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            this.ViewData["Curencies"] = this.context.Curencies.ToList();

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
                CurencyId = model.Curency,
                Balance = model.Charge,
            });

            this.context.SaveChanges();
            return Redirect("/Users/Accounts");
        }

        public IActionResult AllMyLoans(MyOrderedLoansViewModel model)
        {
            List<OrderLoan> AllOrderLoansFormDb = this.context
                .OrderLoans
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account.Curency)
                .Where(orderLoan => orderLoan.BuyerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .ToList();

            var viewAllOrderLoans = AllOrderLoansFormDb
                .Select(loanFromDb => new MyOrderedLoansViewModel
                {
                    Amount = loanFromDb.Amount,
                    MonthlyFee = loanFromDb.MonthlyFee,
                    Period = loanFromDb.Period,
                    Name = loanFromDb.Loan.Name,
                    Id = loanFromDb.Id,
                    Status = loanFromDb.Status.ToString(),
                    CurencyIso = loanFromDb.Loan.Account.Curency.IsoCode
                });

            return View(viewAllOrderLoans);
        }

        [HttpGet("/Users/MyLoan/{id}")]
        public IActionResult MyLoan(string id)
        {
            OrderLoan orderLoanFromDB = this.context
                .OrderLoans
                .Include(orderLoan => orderLoan.Account)
                .ThenInclude(orderLoan => orderLoan.Curency)
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Seller)
                .Include(orderLoan => orderLoan.Loan)
                .ThenInclude(loan => loan.Account.Curency)
                .SingleOrDefault(orderLoan => orderLoan.Id == id);

            var detailOrderLoan = new MyOrderedLoansDetailViewModel()
            {
                Name = orderLoanFromDB.Name,
                Period = orderLoanFromDB.Period,
                Amount = orderLoanFromDB.Amount,
                MonthlyFee = orderLoanFromDB.MonthlyFee,
                Commission = orderLoanFromDB.CostPrice,
                Seller = orderLoanFromDB.Loan.Seller.Name,
                InterestRate = orderLoanFromDB.InterestRate,
                IssuedOn = orderLoanFromDB.IssuedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                Status = orderLoanFromDB.Status.ToString(),
                CompletedOn = orderLoanFromDB.CompletedOn.ToString(),
                CurencyIso = orderLoanFromDB.Loan.Account.Curency.IsoCode,
                DueAmount = orderLoanFromDB.MonthlyFee * orderLoanFromDB.Period,
                Account = orderLoanFromDB.Account.IBAN + " | " + orderLoanFromDB.Account.Curency.Name
            };

            return View(detailOrderLoan);
        }
    }
}