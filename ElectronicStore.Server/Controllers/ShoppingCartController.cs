using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartAccess _shoppingCartAccess;

        public ShoppingCartController(ShoppingCartAccess shoppingCartAccess)
        {
            _shoppingCartAccess = shoppingCartAccess;
        }

        [HttpGet("{shoppingCartId}", Name = "GetShoppingCartById")]
        public ActionResult<ShoppingCart> GetById(int shoppingCartId)
        {
            var shoppingCart = _shoppingCartAccess.GetShoppingCartById(shoppingCartId);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return shoppingCart;
        }

        [HttpGet(Name = "GetAllShoppingCarts")]
        public ActionResult<IEnumerable<ShoppingCart>> GetAll()
        {
            var shoppingCarts = _shoppingCartAccess.GetAllShoppingCart();
            return Ok(shoppingCarts);
        }

        [HttpPost(Name = "AddShoppingCart")]
        public IActionResult Add(ShoppingCart shoppingCart)
        {
            _shoppingCartAccess.AddShoppingCart(shoppingCart);
            return CreatedAtRoute("GetShoppingCartById", new { shoppingCartId = shoppingCart.ShoppingCartId }, shoppingCart);
        }

        [HttpPut("{shoppingCartId}", Name = "UpdateShoppingCart")]
        public IActionResult Update(int shoppingCartId, ShoppingCart shoppingCart)
        {
            if (shoppingCartId != shoppingCart.ShoppingCartId)
            {
                return BadRequest();
            }

            _shoppingCartAccess.UpdateShoppingCart(shoppingCart);
            return NoContent();
        }

        [HttpDelete("{shoppingCartId}", Name = "DeleteShoppingCart")]
        public IActionResult Delete(int shoppingCartId)
        {
            _shoppingCartAccess.DeleteShoppingCart(shoppingCartId);
            return NoContent();
        }
    }
}
