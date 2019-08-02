using System.Collections.Generic;
using AutoMapper;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        
        public IActionResult Loans()
        {
            var loansFromDb = this.productsService.GetAllActiveLoans();

            var view = mapper.Map<List<ProductsLoansViewModel>>(loansFromDb);

            return View(view);
        }

        [HttpGet("/Products/LoanDetails/{id}")]
        public IActionResult LoanDetails(string id)
        {
            var loanFromDb = this.productsService.GetProductById(id);

            var view = mapper.Map<ProductsLoanDetailsViewModel>(loanFromDb);

            return this.View(view);
        }

        //TODO add other products!!!
    }
}