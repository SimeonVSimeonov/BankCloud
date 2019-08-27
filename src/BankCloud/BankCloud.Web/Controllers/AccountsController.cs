﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.BindingModels.Accounts;
using BankCloud.Models.ViewModels.Users;
using BankCloud.Services.Common;
using BankCloud.Services.Interfaces;
using BankCloud.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountsService accountsService;
        private readonly ITransferService transferService;
        private readonly IUsersService usersService;
        private readonly ICloudinaryService cloudinaryService;

        public AccountsController(IMapper mapper, IAccountsService accountsService,
            IUsersService usersService, ICloudinaryService cloudinaryService, ITransferService transferService)
        {
            this.mapper = mapper;
            this.accountsService = accountsService;
            this.usersService = usersService;
            this.cloudinaryService = cloudinaryService;
            this.transferService = transferService;
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
        public async Task<IActionResult> Create(AccountInputModel model)
        {
            string adUrl = await this.cloudinaryService.UploadPictureAsync(model.AdUrl, model.Currency);

            Account account = this.mapper.Map<Account>(model);

            account.AdUrl = adUrl;

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.accountsService.AddAccountToUser(account);

            return Redirect("Index");
        }

        [Authorize]
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
                if (!ModelState.IsValid)
                {
                    return this.View(model);
                }

                return this.RedirectToAction("ChargeBankCloud", "Accounts", model);
            }

            //TODO: For additional pay services
            if (model.Type == TransferType.Card)
            {

            }

            return Redirect("Accounts");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChargeBankCloud(AccountsChargeInputModel model)
        {
            TempData.Put("charge", model);

            return this.View();
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ChargeBankCloud(string iban)
        {
            var chargeData = TempData.Get<AccountsChargeInputModel>("charge");

            var bankCloudCharge = this.mapper.Map<ChargeBankCloudInputModel>(chargeData);

            var grantAccount = this.accountsService.GetAccountByIban(iban);

            if (grantAccount == null || bankCloudCharge.Id == grantAccount.Id)
            {
                this.TempData["error"] = GlobalConstants.MISSING_BANKCLOUD_ACCOUNT;
                return this.RedirectToAction("Charge", chargeData);
            }
            Transfer transfer = this.mapper.Map<Transfer>(bankCloudCharge);
            transfer.ForeignAccountId = grantAccount.Id;
            transfer.BalanceType = BalanceType.Positive;

            this.transferService.AddBankCloudTransfer(transfer);

            return this.Redirect("/Accounts/Index");
        }

        [Authorize]
        public IActionResult Transfer()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Transfer(TransferBankCloudInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var grantAccount = this.accountsService.GetAccountById(model.Id);
            if (grantAccount.Balance < model.Amount)
            {
                this.TempData["error"] = GlobalConstants.INSUFFICIENT_FUNDS;
                return this.View(model);
            }

            var receiverAccount = this.accountsService.GetAccountByIban(model.IBAN);
            if (receiverAccount == null || grantAccount.Id == receiverAccount.Id)
            {
                this.TempData["error"] = GlobalConstants.MISSING_IBAN_ACCOUNT;
                return this.View(model);
            }

            this.transferService.DoTransfer(model, grantAccount, receiverAccount);

            return this.Redirect("/Accounts/Index");
        }

        [Authorize]
        [HttpGet("/Accounts/Detail/{id}")]
        public IActionResult Detail(string id)
        {
            return this.View();
        }
    }
}