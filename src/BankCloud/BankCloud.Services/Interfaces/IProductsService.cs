using BankCloud.Data.Entities;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAllActiveProducts();

        IEnumerable<Product> GetAllActiveLoans();
        IEnumerable<Product> GetAllActiveSaves();
        IEnumerable<Product> GetAllActiveInsurance();
        IEnumerable<Product> GetAllActiveInvestment();

        Product GetProductById(string id);

        void AddProduct(Product product);
    }
}
