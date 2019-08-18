using System;
using System.Linq;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankCloud.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BankCloud.Web.Controllers
{
    public class SellsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountsService accountsService;
        private readonly IProductsService productsService;
        private readonly ICloudinaryService cloudinaryService;


        public SellsController(IAccountsService accountsService, IMapper mapper, 
            IProductsService productsService, ICloudinaryService cloudinaryService)
        {
            this.accountsService = accountsService;
            this.mapper = mapper;
            this.productsService = productsService;
            this.cloudinaryService = cloudinaryService;
        }

        [Authorize(Roles = "Agent")]
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
        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LoanSell(SellsLoanInputModel model)
        {
            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            var userAccountsIds = this.accountsService.GetUserAccountsIds();

            if (!userAccountsIds.Contains(model.AccountId))
            {
                return this.Redirect("/Sells/LoanSell");
            }

            string adUrl = await this.cloudinaryService.UploadPictureAsync(model.AdUrl, model.Name);

            Loan loan = this.mapper.Map<Loan>(model);

            loan.AdUrl = adUrl;
            
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.productsService.AddProduct(loan);

            return Redirect("/Products/Loans");
        }

        [Authorize(Roles = "Agent")]
        public IActionResult SaveSell()
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
        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveSell(SellsSaveInputModel model)
        {
            this.ViewData["Accounts"] = this.accountsService.GetUserAccounts();

            var userAccountsIds = this.accountsService.GetUserAccountsIds();

            if (!userAccountsIds.Contains(model.AccountId))
            {
                return this.Redirect("/Sells/SaveSell");
            }

            string adUrl = await this.cloudinaryService.UploadPictureAsync(model.AdUrl, model.Name);

            Save save = this.mapper.Map<Save>(model);

            save.AdUrl = adUrl;

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.productsService.AddProduct(save);

            return Redirect("/Products/Saves");
        }

        //TODO: add other categories
    }
}