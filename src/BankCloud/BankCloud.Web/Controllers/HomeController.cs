using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BankCloud.Web.Models;
using BankCloud.Models.ViewModels;
using BankCloud.Services.Interfaces;
using AutoMapper;
using System.Linq;

namespace BankCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var productsFromDb = this.productsService.GetAllActiveProducts()
                .OrderByDescending(x => x.IssuedOn).Take(9);

            var view = this.mapper.Map<List<IndexViewModel>>(productsFromDb);

            return View(view);
        }

        public IActionResult Categories()
        {
            var productsFromDb = this.productsService.GetAllActiveProducts();

            var view = this.mapper.Map<List<HomeCategoriesViewModel>>(productsFromDb);

            return View(view);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
