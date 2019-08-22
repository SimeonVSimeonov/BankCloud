using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Models.ViewModels;
using BankCloud.Models.ViewModels.Orders;
using BankCloud.Models.ViewModels.Products;
using BankCloud.Models.ViewModels.Users;
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
        public IActionResult Products()
        {
            var types = this.productsService.GetAllProductTypes()
                .Select(x => x.Name.ToString());
            var myProductFromDb = this.productsService.GetAllAgentProducts();

            var myProducts = mapper.Map<IEnumerable<UsersProductsViewModel>>(myProductFromDb);

            var allOrderedFormDb = this.ordersService.GetAllOrderedByCurrentUser();

            var allOrdered = mapper.Map<IEnumerable<AllOrdersViewModel>>(allOrderedFormDb);

            var view = new UsersProductsPanelViewModel
            {
                Type = types,
                Products = myProducts,
                Orders = allOrdered
            };

            return View(view);
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

            return View(detailOrderLoan);

        }

        [Authorize(Roles = "Agent")]
        public IActionResult ProductSaves()
        {
            var agentSavesFromDb = this.productsService.GetAllAgentActiveSaves();

            var view = this.mapper.Map<List<ProductsSavesViewModel>>(agentSavesFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/Users/ProductSaveDetails/{id}")]
        public IActionResult ProductSaveDetails(string id)
        {
            Product product = this.productsService.GetProductById(id);

            var view = this.mapper.Map<ProductsSaveDetailsViewModel>(product);

            return this.View(view);
        }

        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public IActionResult SaveDelete(string id)
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

            var view = this.mapper.Map<ProductsSaveDetailsViewModel>(product);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpPost, ActionName("SaveDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDeleteConfirmed(string id)
        {

            var pendingSaveIds = this.ordersService.GetAgentOrderSavesIds();

            if (pendingSaveIds.Contains(id))
            {
                return this.Redirect("/CreditScorings/PendingRequests");
            }

            this.productsService.ArchiveProduct(id);

            return Redirect("/Users/ProductSaves");

        }

        [Authorize(Roles = "Agent")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ArchivedProductSaves()
        {
            var saveFromDb = this.productsService.GetAllAgentArchivedSaves();

            var view = this.mapper.Map<List<ProductsSavesViewModel>>(saveFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/Users/RestoreProductSave/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult RestoreProductSave(string id)
        {
            this.productsService.RestoreProduct(id);

            return this.Redirect("/Users/ProductSaves");
        }

        [Authorize]
        public IActionResult OrderedSaves()
        {
            IEnumerable<OrderSave> userOrderedSavesFromDB = this.ordersService.GetOrderedSavesByCurrentUser();

            var viewAllOrderSaves = this.mapper
                 .Map<List<UsersOrderedSavesViewModel>>(userOrderedSavesFromDB);

            return View(viewAllOrderSaves);
        }
    }
}