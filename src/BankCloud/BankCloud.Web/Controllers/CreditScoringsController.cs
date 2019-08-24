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
        public IActionResult LoanPendingRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Pending);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult SavePendingRequests()
        {
            var orderedSavesFromDb = this.ordersService.GetSoldOrderSaves()
                .Where(orderSave => orderSave.Status == OrderStatus.Pending);

            var view = this.mapper.Map<List<CreditScoringsOrderedSavesViewModel>>(orderedSavesFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult LoanApprovedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Approved);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult SaveApprovedRequests()
        {
            var orderedSavesFromDb = this.ordersService.GetSoldOrderSaves()
                .Where(orderSave => orderSave.Status == OrderStatus.Approved);

            var view = this.mapper.Map<List<CreditScoringsOrderedSavesViewModel>>(orderedSavesFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult LoanRejectedRequests()
        {
            var orderedLoansFromDb = this.ordersService.GetSoldOrderLoans()
                .Where(orderLoan => orderLoan.Status == OrderStatus.Rejected);

            var view = this.mapper.Map<List<CreditScoringsOrderedLoansViewModel>>(orderedLoansFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        public IActionResult SaveRejectedRequests()
        {
            var orderedSaveFromDb = this.ordersService.GetSoldOrderSaves()
               .Where(orderSave => orderSave.Status == OrderStatus.Rejected);

            var view = this.mapper.Map<List<CreditScoringsOrderedSavesViewModel>>(orderedSaveFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/LoanDetailRequest/{id}")]
        public IActionResult LoanDetailRequest(string id)
        {
            Order orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            var view = this.mapper.Map<Order, CreditScoringsOrderedLoanDetailViewModel>(orderedLoanFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/SaveDetailRequest/{id}")]
        public IActionResult SaveDetailRequest(string id)
        {
            Order orderedSaveFromDb = this.ordersService.GetSoldOrderSaveById(id);

            var view = this.mapper.Map<Order, CreditScoringsOrderedSaveDetailViewModel>(orderedSaveFromDb);

            return View(view);
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/ApproveLoan/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ApproveLoan(string id)
        {
            OrderLoan orderedLoanFromDb = this.ordersService.GetSoldOrderLoanById(id);

            Account sellerAccount = orderedLoanFromDb.Loan.Account;
            
            if (sellerAccount.Balance < orderedLoanFromDb.Amount)
            {
                this.TempData["error"] = GlobalConstants.ERROR_MESSAGE_FOR_INSUFFICIENT_FUNDS;

                return this.Redirect("/Accounts/Index");
            }

            this.ordersService.ApproveLoanRequest(orderedLoanFromDb);

            return Redirect("/CreditScorings/MySells");
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/ApproveSave/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ApproveSave(string id)
        {
            OrderSave orderedSaveFromDb = this.ordersService.GetSoldOrderSaveById(id);

            var depositorAccount = orderedSaveFromDb.Account;

            Account sellerAccount = orderedSaveFromDb.Save.Account;

            if (depositorAccount.Balance < orderedSaveFromDb.Amount)
            {
                this.TempData["error"] = GlobalConstants.ERROR_MESSAGE_FOR_DEPOSITOR_DOES_NOT_HAVE_MONEY;
                var view = this.mapper.Map<Order, CreditScoringsOrderedSaveDetailViewModel>(orderedSaveFromDb);
                return this.View("SaveDetailRequest", view);
            }

            this.ordersService.ApproveSaveRequest(orderedSaveFromDb);

            return Redirect("/CreditScorings/MySells");
        }

        [Authorize(Roles = "Agent")]
        [HttpGet("/CreditScorings/RejectRequest/{id}")]
        [AutoValidateAntiforgeryToken]
        public IActionResult RejectRequest(string id)
        {
            Order orderedFromDb = this.ordersService.GetOrderById(id);

            this.ordersService.RejectRequest(orderedFromDb);

            return Redirect("/CreditScorings/MySells");
        }
    }
}