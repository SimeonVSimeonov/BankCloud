using BankCloud.Data.Entities;
using System;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Type> GetAllProductTypes();
        IEnumerable<Product> GetAllAgentProducts();

        IEnumerable<Product> GetAllActiveProducts();

        IEnumerable<Product> GetAllActiveLoans();
        IEnumerable<Product> GetAllAgentActiveLoans();
        IEnumerable<Product> GetAllAgentArchivedLoans();

        IEnumerable<Product> GetAllActiveSaves();
        IEnumerable<Product> GetAllAgentActiveSaves();
        IEnumerable<Product> GetAllAgentArchivedSaves();

        IEnumerable<Product> GetAllActiveInsurance();
        IEnumerable<Product> GetAllActiveInvestment();

        void ArchiveProduct(string id);

        void RestoreProduct(string id);

        Product GetProductById(string id);

        void AddProduct(Product product);
    }
}
