﻿using System;
using System.Linq;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankCloud.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BankCloud.Web.Controllers
{
    public class SellsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountsService accountsService;
        private readonly IProductsService productsService;


        public SellsController(IAccountsService accountsService, IMapper mapper, 
            IProductsService productsService)
        {
            this.accountsService = accountsService;
            this.mapper = mapper;
            this.productsService = productsService;
        }

        [Authorize]
        public IActionResult LoanSell()
        {
            var userAccounts = this.accountsService.GetUserAccounts();

            this.ViewData["Accounts"] = userAccounts;
            
            if (!userAccounts.Any())
            {
                return this.Redirect("/Accounts/Activate");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult LoanSell(SellsLoanInputModel model)
        {
            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            var userAccountsIds = this.accountsService.GetUserAccountsIds();

            if (!userAccountsIds.Contains(model.AccountId))
            {
                return this.Redirect("/Sells/LoanSell");
            }
            
            Loan loan = this.mapper.Map<Loan>(model);
            
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.productsService.AddProduct(loan);

            return Redirect("/Products/Loans");
        }
    }
}