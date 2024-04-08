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
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryAccess _productCategoryAccess;

        public ProductCategoryController(ProductCategoryAccess productCategoryAccess)
        {
            _productCategoryAccess = productCategoryAccess;
        }

        [HttpGet("{categoryId}", Name = "GetProductCategoryById")]
        public ActionResult<ProductCategory> GetById(int categoryId)
        {
            var category = _productCategoryAccess.GetProductCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpGet(Name = "GetAllProductCategories")]
        public ActionResult<IEnumerable<ProductCategory>> GetAll()
        {
            var categories = _productCategoryAccess.GetAllProductCategory();
            return Ok(categories);
        }

        [HttpPost(Name = "AddProductCategory")]
        public IActionResult Add(ProductCategory category)
        {
            _productCategoryAccess.AddProductCategory(category);
            return CreatedAtRoute("GetProductCategoryById", new { categoryId = category.ProductCategoryId }, category);
        }

        [HttpPut("{categoryId}", Name = "UpdateProductCategory")]
        public IActionResult Update(int categoryId, ProductCategory category)
        {
            if (categoryId != category.ProductCategoryId)
            {
                return BadRequest();
            }

            _productCategoryAccess.UpdateProductCategory(category);
            return NoContent();
        }

        [HttpDelete("{categoryId}", Name = "DeleteProductCategory")]
        public IActionResult Delete(int categoryId)
        {
            _productCategoryAccess.DeleteProductCategory(categoryId);
            return NoContent();
        }
    }
}
