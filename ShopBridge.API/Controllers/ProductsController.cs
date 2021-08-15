using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.API.Model;
using ShopBridge.API.Model.Repository;
using ShopBridge.API.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{

    /// <summary>
    /// Products Web API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepository;
        private readonly ILogger<ProductsController> logger;


        public ProductsController(IProductRepository _productRepository
            , ILogger<ProductsController> _logger
            )
        {
            this.productRepository = _productRepository;
            this.logger = _logger; 
        }

        /// <summary>
        /// Get Products - Default limit for products is 10
        /// </summary>
        /// <param name="productRequest">Product Request Param</param>
        /// <returns>Products list</returns>
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery]ProductRequest productRequest)
        {
            logger.LogInformation("Get Products Requested");
            return Ok(await productRepository.GetProducts(productRequest));
        }


        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <returns>Product details for given product id</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return Ok(await productRepository.GetProduct(id));
        }


        /// <summary>
        /// Save product
        /// </summary>
        /// <param name="product">product to be saved</param>
        /// <returns>Saved product</returns>
        [HttpPost]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            var newEntry = await productRepository.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct),
                new { id = newEntry.Id }, newEntry);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="product">update product object</param>
        /// <returns>Updated product</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("id not matching with update product id property");

            Product p = await productRepository.GetProduct(product.Id);

            if (p == null)
                return NotFound($"Product not available for ID {product.Id}");

            return await productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>Ok if product deleted</returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product p = await productRepository.GetProduct(id);

            if (p == null)
                return NotFound($"Product not available for ID {id}");

            await productRepository.DeleteProduct(id);

            return Ok($"Product with id = {id} deleted");
        }

    }
}
