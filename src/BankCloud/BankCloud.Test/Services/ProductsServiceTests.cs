using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace BankCloud.Test.Services
{
    public class ProductsServiceTests
    {
        [Fact]
        public void AddProductShouldAddProduct()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var product = new Loan { Name = "ABCD" };
            productService.AddProduct(product);

            var products = dbContext.Products.ToList();

            Assert.Single(products);
            Assert.Equal(product.Name, products.First().Name);
        }

        [Fact]
        public void GetAllActiveProductsShouldReturnActiveProducts()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_Active_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var save = new Save { Name = "dcba", IsDeleted = false};
            var save1 = new Save { Name = "1234", IsDeleted = true};
            dbContext.Products.Add(loan);
            dbContext.Products.Add(save);
            dbContext.Products.Add(save1);
            dbContext.SaveChanges();
            var products = dbContext.Products.Where(x => x.IsDeleted == false);

            var returnedActiveProducts = productService.GetAllActiveProducts();

            Assert.Equal(2, returnedActiveProducts.Count());
            Assert.Equal(products, returnedActiveProducts);
        }

        [Fact]
        public void GetAllActiveLoansShouldReturnActiveLoans()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_ActiveLoans_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var loan1 = new Loan { Name = "ddsdf", IsDeleted = false };
            var loan2 = new Loan { Name = "1235", IsDeleted = true };
            var save = new Save { Name = "dcba", IsDeleted = false };
            var save1 = new Save { Name = "1234", IsDeleted = true };
            dbContext.Products.Add(loan);
            dbContext.Products.Add(loan1);
            dbContext.Products.Add(loan2);
            dbContext.Products.Add(save);
            dbContext.Products.Add(save1);
            dbContext.SaveChanges();

            var returnedLoans = productService.GetAllActiveLoans();

            Assert.Equal(2, returnedLoans.Count());
        }

        [Fact]
        public void GetAllActiveSavesShouldReturnActiveSaves()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_ActiveSaves_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var loan2 = new Loan { Name = "1235", IsDeleted = true };
            var save = new Save { Name = "dcba", IsDeleted = false };
            var save2 = new Save { Name = "ddsdf", IsDeleted = false };
            var save1 = new Save { Name = "1234", IsDeleted = true };
            dbContext.Products.Add(loan);
            dbContext.Products.Add(loan2);
            dbContext.Products.Add(save);
            dbContext.Products.Add(save1);
            dbContext.Products.Add(save2);
            dbContext.SaveChanges();

            var returnedSaves = productService.GetAllActiveSaves();

            Assert.Equal(2, returnedSaves.Count());
        }

        [Fact]
        public void GetAllActiveInvestmentShouldReturnActiveSaves()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_ActiveInvestment_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var loan2 = new Loan { Name = "1235", IsDeleted = true };
            var invest = new Investment { Name = "dcba", IsDeleted = false };
            var invest1 = new Investment { Name = "ddsdf", IsDeleted = false };
            var invest2 = new Investment { Name = "1234", IsDeleted = true };
            dbContext.Products.Add(loan);
            dbContext.Products.Add(loan2);
            dbContext.Products.Add(invest);
            dbContext.Products.Add(invest2);
            dbContext.Products.Add(invest1);
            dbContext.SaveChanges();

            var returnedSaves = productService.GetAllActiveInvestment();

            Assert.Equal(2, returnedSaves.Count());
        }

        [Fact]
        public void GetAllActiveInsuranceShouldReturnActiveSaves()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_ActiveInsurance_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var loan2 = new Loan { Name = "1235", IsDeleted = true };
            var insure = new Insurance { Name = "dcba", IsDeleted = false };
            var insure1 = new Insurance { Name = "ddsdf", IsDeleted = false };
            var insure2 = new Insurance { Name = "1234", IsDeleted = true };
            dbContext.Products.Add(loan);
            dbContext.Products.Add(loan2);
            dbContext.Products.Add(insure);
            dbContext.Products.Add(insure2);
            dbContext.Products.Add(insure1);
            dbContext.SaveChanges();

            var returnedSaves = productService.GetAllActiveInsurance();

            Assert.Equal(2, returnedSaves.Count());
        }

        [Fact]
        public void GetProductByIdShouldReturCorrectProduct()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Return_Product_By_Id_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loan = new Loan { Name = "abcd", IsDeleted = false };
            var loan2 = new Loan { Name = "1235", IsDeleted = true };
            var save = new Save { Name = "dcba", IsDeleted = false };
            var save2 = new Save { Name = "ddsdf", IsDeleted = false };
            var save1 = new Save { Name = "1234", IsDeleted = true };
            dbContext.Products.Add(loan);
            dbContext.Products.Add(loan2);
            dbContext.Products.Add(save);
            dbContext.Products.Add(save1);
            dbContext.Products.Add(save2);
            dbContext.SaveChanges();

            var product = productService.GetProductById(save.Id);
            var product1 = productService.GetProductById(loan2.Id);

            Assert.Equal(product.Id, save.Id);
            Assert.Equal(product1.Id, loan2.Id);
        }

        [Fact]
        public void ArchiveProductShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Archive_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loanId = "123";
            var saveId = "321";
            var productLoan = new Loan { Id = loanId, Name = "ABC", IsDeleted = false };
            var productSave = new Save { Id = saveId, Name = "CBA", IsDeleted = false };
            dbContext.Products.Add(productLoan);
            dbContext.Products.Add(productSave);
            dbContext.SaveChanges();

            productService.ArchiveProduct(loanId);
            productService.ArchiveProduct(saveId);

            var loan = dbContext.Products.Find(loanId);
            var save = dbContext.Products.Find(saveId);

            Assert.True(loan.IsDeleted);
            Assert.True(save.IsDeleted);
        }

        [Fact]
        public void RestoreProductShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<BankCloudDbContext>()
                .UseInMemoryDatabase(databaseName: "Restore_Product_Database")
                .Options;

            var dbContext = new BankCloudDbContext(options);

            var productService = new ProductsService(dbContext, null);

            var loanId = "123";
            var saveId = "321";
            var productLoan = new Loan { Id = loanId, Name = "ABC", IsDeleted = true };
            var productSave = new Save { Id = saveId, Name = "CBA", IsDeleted = true };
            dbContext.Products.Add(productLoan);
            dbContext.Products.Add(productSave);
            dbContext.SaveChanges();

            productService.RestoreProduct(loanId);
            productService.RestoreProduct(saveId);

            var loan = dbContext.Products.Find(loanId);
            var save = dbContext.Products.Find(saveId);

            Assert.False(loan.IsDeleted);
            Assert.False(save.IsDeleted);
        }
    }
}
