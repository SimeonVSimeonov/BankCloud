using System.Linq;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Orders;
using BankCloud.Services.Common;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class OrdersController : Controller
    {
        
        private readonly IMapper mapper;
        private readonly IProductsService productsService;
        private readonly IUsersService usersService;
        private readonly IAccountsService accountsService;
        private readonly IOrdersService ordersService;

        public OrdersController(IProductsService productsService, IUsersService usersService,
            IMapper mapper, IAccountsService accountsService, IOrdersService ordersService)
        {
            
            this.productsService = productsService;
            this.usersService = usersService;
            this.mapper = mapper;
            this.accountsService = accountsService;
            this.ordersService = ordersService;
        }

        [Authorize]
        [HttpGet("/Orders/OrderLoan/{id}")]
        public IActionResult OrderLoan(string id)
        {
            Product loanFromDb = this.productsService.GetProductById(id);

            BankUser userFromDb = this.usersService.GetCurrentUser();

            if (!userFromDb.Accounts.Any())
            {
                return this.Redirect("/Accounts/Activate");
            }

            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            var view = this.mapper.Map<OrdersOrderLoanInputModel>(loanFromDb);

            view.UserCurrencyTypes = this.accountsService.GetUserAccounts()
                .Select(x => x.Currency.Name).ToList();

            view.MonthlyFee = BankCloudCalculator.CalculateMounthlyFee(loanFromDb);

            return View(view);
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult OrderLoan(OrdersOrderLoanInputModel model)
        {
            Product loanFromDb = this.productsService.GetProductById(model.Id);

            BankUser userFromDb = this.usersService.GetCurrentUser();

            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();
            
            OrderLoan order = this.mapper.Map<OrderLoan>(model);

            if (userFromDb.Id == loanFromDb.Account.BankUserId)
            {
                return this.Redirect("/");
            }

            if (!userFromDb.Accounts.Any())
            {
                return this.Redirect("/Accounts/Activate");
            }
            //TODO: add message for invalid parameters
            if (!ModelState.IsValid || model.Amount > loanFromDb.Amount
                || model.Period > loanFromDb.Period
                || model.InterestRate != loanFromDb.InterestRate)
            {
                //TODO: refactor this!!!
                model.Name = loanFromDb.Name;
                model.CurrencyName = loanFromDb.Account.Currency.Name;
                model.UserCurrencyTypes = this.accountsService.GetUserAccounts()
                .Select(x => x.Currency.Name).ToList();
                return this.View(model);
            }

            this.ordersService.AddOrderLoan(order, loanFromDb);

            return this.Redirect("/Users/OrderedLoans");
        }

        [Authorize]
        [HttpGet("/Orders/OrderSave/{id}")]
        public IActionResult OrderSave(string id)
        {
            Product saveFromDb = this.productsService.GetProductById(id);

            BankUser userFromDb = this.usersService.GetCurrentUser();

            if (!userFromDb.Accounts.Any())
            {
                return this.Redirect("/Accounts/Activate");
            }

            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            var view = this.mapper.Map<OrdersOrderSaveInputModel>(saveFromDb);

            view.UserCurrencyTypes = this.accountsService.GetUserAccounts()
                .Select(x => x.Currency.Name).ToList();

            return this.View(view);
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult OrderSave(OrdersOrderSaveInputModel model)
        {
            Product saveFromDb = this.productsService.GetProductById(model.Id);

            BankUser userFromDb = this.usersService.GetCurrentUser();

            if (userFromDb.Id == saveFromDb.Account.BankUserId)
            {
                return this.Redirect("/");
            }

            if (!userFromDb.Accounts.Any())
            {
                return this.Redirect("/Accounts/Activate");
            }

            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            OrderSave order = this.mapper.Map<OrderSave>(model);

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.ordersService.AddOrderSave(order, saveFromDb);

            return this.Redirect("/Users/OrderedSaves");
        }
    }
}