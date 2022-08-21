using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _productContext;

        public ProductController(ILogger<ProductController> logger, ProductContext productContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }
    }
}