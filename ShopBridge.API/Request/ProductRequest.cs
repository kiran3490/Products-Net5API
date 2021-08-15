using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public int Limit { get; set; }

        /// <summary>
        /// Offset for product
        /// </summary>
        [FromQuery(Name = "offset")]
        public int Offset { get; set; }
    }
}
