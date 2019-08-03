using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BankCloud.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrdersService ordersService;
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;

        public UsersController(IUsersService usersService, IProductsService productsService,
            IOrdersService ordersService, IMapper mapper)
        {
            this.usersService = usersService;
            this.ordersService = ordersService;
            this.mapper = mapper;
            this.productsService = productsService;
        }

        [Authorize]
        public IActionResult Products(string id)
        {
            return View();
        }


        [Authorize(Roles = "Agent")]
        public IActionResult ProductLoans()
        {
            var agentLoansFromDb = this.productsService.GetAllAgentActiveLoans();

            var view = this.mapper.Map<List<ProductsLoansViewModel>>(agentLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/Users/ProductLoanDetails/{id}")]
        public IActionResult ProductLoanDetails(string id)
        {
            Product product = this.productsService.GetProductById(id);

            var view = this.mapper.Map<ProductsLoanDetailsViewModel>(product);

            return this.View(view);
        }

        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public IActionResult LoanDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = this.productsService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var view = this.mapper.Map<ProductsLoanDetailsViewModel>(product);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpPost, ActionName("LoanDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult LoanDeleteConfirmed(string id)
        {

            var pendingLoanIds = this.ordersService.GetAgentOrderLoansIds();

            if (pendingLoanIds.Contains(id))
            {
                return this.Redirect("/CreditScorings/PendingRequests");
            }

            this.productsService.ArchiveProduct(id);
            
            return Redirect("/Users/ProductLoans");

        }

        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ArchivedProductLoans()
        {
            var loanFromDb = this.productsService.GetAllAgentArchivedLoans();

            var view = this.mapper.Map<List<ProductsLoansViewModel>>(loanFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/Users/RestoreProductloan/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult RestoreProductloan(string id)
        {
            this.productsService.RestoreProduct(id);

            return this.Redirect("/Users/ProductLoans");
        }

        [Authorize]
        public IActionResult OrderedLoans()
        {
            IEnumerable<OrderLoan> userOrderedLoanFromDB = this.ordersService.GetOrderedLoansByCurrentUser();

           var viewAllOrderLoans = this.mapper
                .Map<List<UsersOrderedLoansViewModel>>(userOrderedLoanFromDB);

            return View(viewAllOrderLoans);
        }

        [Authorize]
        [HttpGet("/Users/OrderedLoanDetails/{id}")]
        public IActionResult OrderedLoanDetails(string id)
        {
            OrderLoan userOrderedLoanFromDB = this.ordersService.GetOrderLoanById(id);

            var detailOrderLoan = this.mapper
                .Map<OrderedLoansDetailViewModel>(userOrderedLoanFromDB);

            //TODO refactor this
            detailOrderLoan.Account = userOrderedLoanFromDB.Account.IBAN + " | " + userOrderedLoanFromDB.Account.Currency.Name;
            detailOrderLoan.DueAmount = userOrderedLoanFromDB.MonthlyFee * userOrderedLoanFromDB.Period;

            return View(detailOrderLoan);

        }
    }
}