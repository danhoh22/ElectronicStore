using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductAccess _productAccess;

        public ProductController(ProductAccess productAccess)
        {
            _productAccess = productAccess;
        }

        [HttpGet("{productId}", Name = "GetProductById")]
        public ActionResult<Product> GetById(int productId)
        {
            var product = _productAccess.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet(Name = "GetProduct")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productAccess.GetAllProduct();
            return Ok(products);
        }

        [HttpPost(Name = "AddProduct")]
        public IActionResult Add(Product product)
        {
            _productAccess.AddProduct(product);
            return CreatedAtRoute("GetProductById", new { productId = product.ProductId }, product);
        }

        [HttpPut("{productId}", Name = "UpdateProduct")]
        public IActionResult Update(int productId, Product product)
        {
            if (productId != product.ProductId)
            {
                return BadRequest();
            }

            _productAccess.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{productId}", Name = "DeleteProduct")]
        public IActionResult Delete(int productId)
        {
            _productAccess.DeleteProduct(productId);
            return NoContent();
        }
    }
}
