using BankCloud.Data.Entities;
using BankCloud.Data.Context;
using System.Collections.Generic;
using BankCloud.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankCloud.Services
{
    public class ProductsService : IProductsService
    {
        private readonly BankCloudDbContext context;

        public ProductsService(BankCloudDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAllActiveLoans()
        {
            return this.context.Products
                .Where(product => product.GetType().Name == "Loan" && product.IsDeleted == false)
                .Include(loan => loan.Account.Currency)
                .ToList();
        }

        public Product GetProductById(string id)
        {
            return this.context.Products
                .Where(loan => loan.Id == id)
                .Include(loan => loan.Account)
                .ThenInclude(account => account.BankUser)
                .Include(loan => loan.Account.Currency)
                //.Include(loan => loan.Seller) //TODO check if need Seller Prop?
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
    }
}
