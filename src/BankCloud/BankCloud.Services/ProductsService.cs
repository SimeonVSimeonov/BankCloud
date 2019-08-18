using BankCloud.Data.Entities;
using BankCloud.Data.Context;
using System.Collections.Generic;
using BankCloud.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BankCloud.Services
{
    public class ProductsService : IProductsService
    {
        private readonly BankCloudDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductsService(BankCloudDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Product> GetAllActiveProducts()
        {
            return this.context.Products
                .Where(product => product.IsDeleted == false)
                .Include(loan => loan.Account.Currency);
        }

        public IEnumerable<Product> GetAllAgentActiveLoans()
        {
            var currentAgentId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Products
               .Include(product => product.Account)
               .ThenInclude(account => account.Currency)
               .Where(product => product.GetType().Name == "Loan" &&
               product.Account.BankUserId == currentAgentId &&
               product.IsDeleted == false);
        }

        public IEnumerable<Product> GetAllAgentArchivedLoans()
        {
            var currentAgentId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Products
               .Include(product => product.Account)
               .ThenInclude(account => account.Currency)
               .Where(product => product.GetType().Name == "Loan" &&
               product.Account.BankUserId == currentAgentId &&
               product.IsDeleted == true);
        }

        public IEnumerable<Product> GetAllActiveLoans()
        {
            return this.context.Products
                .Where(product => product.GetType().Name == "Loan" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency);
        }

        public IEnumerable<Product> GetAllActiveSaves()
        {
            return this.context.Products
                .Where(product => product.GetType().Name == "Save" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency);
        }

        public IEnumerable<Product> GetAllActiveInsurance()
        {
            return this.context.Products
                .Where(product => product.GetType().Name == "Insurance" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency);
        }

        public IEnumerable<Product> GetAllActiveInvestment()
        {
            return this.context.Products
                .Where(product => product.GetType().Name == "Investment" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency);
        }

        public Product GetProductById(string id)
        {
            return this.context.Products
                .Where(loan => loan.Id == id)
                .Include(loan => loan.Account)
                .ThenInclude(account => account.BankUser)
                .Include(loan => loan.Account.Currency)
                .SingleOrDefault();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                return;
            }

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void ArchiveProduct(string id)
        {
            Product product = this.context.Products.Find(id);

            if (product == null)
            {
                return;
            }

            product.IsDeleted = true;
            this.context.SaveChanges();
        }

        public void RestoreProduct(string id)
        {
            Product product = this.context.Products.Find(id);

            if (product == null)
            {
                return;
            }

            product.IsDeleted = false;
            this.context.SaveChanges();
        }
    }
}
