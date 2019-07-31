using BankCloud.Data.Entities;
using System.Collections.Generic;

namespace BankCloud.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAllActiveLoans();

        Product GetProductById(string id);

        void AddProduct(Product product);
    }
}
