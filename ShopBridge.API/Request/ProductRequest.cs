using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Request
{
    /// <summary>
    /// Product request parameters
    /// </summary>
    public class ProductRequest
    {
        /// <summary>
        /// Limit for products
        /// </summary>
        [FromQuery(Name = "limit")]
        [Range(typeof(int), "1", "5000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int? Limit { get; set; }

        /// <summary>
        /// Offset for product
        /// </summary>
        [FromQuery(Name = "offset")]
        [Range(typeof(int), "1", "10000", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int? Offset { get; set; }
    }
}
