using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Accounts;
using BankCloud.Models.ViewModels.Users;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountsService accountsService;
        private readonly IUsersService usersService;

        public AccountsController(IMapper mapper, IAccountsService accountsService,
            IUsersService usersService)
        {
            this.mapper = mapper;
            this.accountsService = accountsService;
            this.usersService = usersService;
        }

        public IActionResult Charge()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Charge(AccountsChargeInputModel model)
        {
            if (model.Type == TransferType.BankCloud)
            {
                var accuser = this.accountsService.GetUserAccounts();

                if (accuser.Any(x => x.IBAN == model.Account.ToString()))
                {
                    ;
                }

            }

            if (model.Type == TransferType.Card)
            {
                ;
            }

            return Redirect("Accounts");
        }

        [Authorize]
        public IActionResult Index()
        {
            var userAccountsFromDb = this.accountsService.GetUserAccounts();

            var view = this.mapper.Map<List<UsersAccountViewModel>>(userAccountsFromDb);

            if (!userAccountsFromDb.Any())
            {
                return this.Redirect("Activate");
            }

            return View(view);
        }

        [Authorize]
        public IActionResult Activate()
        {
            var userAccountsFromDb = this.accountsService.GetUserAccounts();

            this.ViewData["Curencies"] = this.accountsService.GetCurrencies().ToList();

            if (!userAccountsFromDb.Any())
            {
                return View();
            }

            return this.Redirect("Index");
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Activate(AccountActivateInputModel model)
        {
            var userFromDb = this.usersService.GetCurrentUser();

            this.mapper.Map(model, userFromDb);

            Account account = this.mapper.Map<Account>(model.Account);

            this.accountsService.AddAccountToUser(account);

            return Redirect("Index");
        }

        [Authorize]
        public IActionResult Create()
        {
            var userAccountsFromDb = this.accountsService.GetUserAccounts();

            this.ViewData["Curencies"] = this.accountsService.GetCurrencies().ToList();

            if (!userAccountsFromDb.Any())
            {
                return this.Redirect("Activate");
            }

            return View();

        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(AccountInputModel model)
        {
            Account account = this.mapper.Map<Account>(model);

            this.accountsService.AddAccountToUser(account);

            return Redirect("Index");
        }
    }
}