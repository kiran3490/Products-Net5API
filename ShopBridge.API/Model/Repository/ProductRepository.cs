using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopBridge.API.Model.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopBridgeDataContext dataContext;
        public ProductRepository(ShopBridgeDataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await dataContext.Products.AddAsync(product);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dataContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await dataContext.Products
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (result != null)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.Quantity = product.Quantity;
                result.Description = product.Description;

                await dataContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteProduct(int id)
        {
            var result = await dataContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                dataContext.Products.Remove(result);
                await dataContext.SaveChangesAsync();
            }
        }

    }
}
