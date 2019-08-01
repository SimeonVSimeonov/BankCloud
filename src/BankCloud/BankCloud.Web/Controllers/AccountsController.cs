using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Common;
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
        public IActionResult Index()
        {
            var userAccountsFromDb = this.accountsService.GetUserAccounts();

            var viewAccounts = this.mapper.Map<List<UsersAccountViewModel>>(userAccountsFromDb);

            if (!userAccountsFromDb.Any())
            {
                return this.Redirect("Activate");
            }

            return View(viewAccounts);
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