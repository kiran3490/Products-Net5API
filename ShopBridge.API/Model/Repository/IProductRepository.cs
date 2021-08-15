using ShopBridge.API.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Model.Repository
{
    public interface IProductRepository
    { 
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProducts(ProductRequest productRequest);

        Task<Product> GetProduct(int id);

        Task<Product> UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
