using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCloud.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace BankCloud.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BankCloudDbContext context;

        public OrdersController(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Loan()
        {
           // var loan  = context.Loans.Where()

            return View();
        }
    }
}