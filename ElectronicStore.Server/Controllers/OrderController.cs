using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderAccess _orderAccess;

        public OrderController(OrderAccess orderAccess)
        {
            _orderAccess = orderAccess;
        }

        [HttpGet("{orderId}", Name = "GetOrderById")]
        public ActionResult<Order> GetById(int orderId)
        {
            var order = _orderAccess.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet(Name = "GetAllOrders")]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            var orders = _orderAccess.GetAllOrder();
            return Ok(orders);
        }

        [HttpPost(Name = "AddOrder")]
        public IActionResult Add(Order order)
        {
            _orderAccess.AddOrder(order);
            return CreatedAtRoute("GetOrderById", new { orderId = order.OrderId }, order);
        }

        [HttpPut("{orderId}", Name = "UpdateOrder")]
        public IActionResult Update(int orderId, Order order)
        {
            if (orderId != order.OrderId)
            {
                return BadRequest();
            }

            _orderAccess.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{orderId}", Name = "DeleteOrder")]
        public IActionResult Delete(int orderId)
        {
            _orderAccess.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
