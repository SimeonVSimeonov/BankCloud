using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Data.Entities.Enums;
using BankCloud.Models.ViewModels.CreditScorings;
using BankCloud.Models.ViewModels.Orders;
using BankCloud.Models.ViewModels.Users;
using BankCloud.Services.Common;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class CreditScoringsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrdersService ordersService;
        private readonly IProductsService productsService;

        public CreditScoringsController(IOrdersService ordersService,
            IMapper mapper, IProductsService productsService)
        {
            this.ordersService = ordersService;
            this.mapper = mapper;
            this.productsService = productsService;
        }

        [Authorize(Roles = "Agent")]
        public IActionResult MySells()
        {
            var types = this.productsService.GetAllProductTypes()
                .Select(x => x.Name.ToString());
            var soldLoansFromDb = this.ordersService.GetSoldOrderLoans();
            var soldSavesFromDb = this.ordersService.GetSoldOrderSaves();

            var soldLoans = this.mapper.Map<List<UsersOrderedLoansViewModel>>(soldLoansFromDb);
            var soldSaves = this.mapper.Map<List<UsersOrderedSavesViewModel>>(soldSavesFromDb);

            var view = new OrdersProductsPanelViewModel()
            {
                Type = types,
                OrderedLoans = soldLoans,
                OrderedSaves = soldSaves
            };
            
            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult PendingRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Pending);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult ApprovedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Approved);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult RejectedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Rejected);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/DetailRequest/{id}")]
        public IActionResult LoanDetailRequest(string id)
        {
            Order orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            var view = this.mapper.Map<Order, CreditScoringsOrderedLoanDetailViewModel>(orderedLoanFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/ApproveRequest/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ApproveRequest(string id)
        {
            OrderLoan orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            Account sellerAccount = orderedLoanFromDb.Loan.Account;

            if (sellerAccount.Balance < orderedLoanFromDb.Amount)
            {
                this.TempData["error"] = GlobalConstants.ERROR_MESSAGE_FOR_INSUFFICIENT_FUNDS;

                return this.Redirect("/Users/Accounts");
            }

            this.ordersService.ApproveRequest(orderedLoanFromDb);

            return Redirect("/CreditScorings/PendingRequests");
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/RejectRequest/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult RejectRequest(string id)
        {
            OrderLoan orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            this.ordersService.RejectRequest(orderedLoanFromDb);

            return Redirect("/CreditScorings/PendingRequests");
        }
    }
}