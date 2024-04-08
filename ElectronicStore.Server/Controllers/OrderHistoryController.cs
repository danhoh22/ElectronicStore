using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly OrderHistoryAccess _orderHistoryAccess;

        public OrderHistoryController(OrderHistoryAccess orderHistoryAccess)
        {
            _orderHistoryAccess = orderHistoryAccess;
        }

        [HttpGet("{orderHistoryId}", Name = "GetOrderHistoryById")]
        public ActionResult<OrderHistory> GetById(int orderHistoryId)
        {
            var orderHistory = _orderHistoryAccess.GetOrderHistoryById(orderHistoryId);
            if (orderHistory == null)
            {
                return NotFound();
            }
            return orderHistory;
        }

        [HttpGet(Name = "GetAllOrderHistories")]
        public ActionResult<IEnumerable<OrderHistory>> GetAll()
        {
            var orderHistories = _orderHistoryAccess.GetAllOrderHistory();
            return Ok(orderHistories);
        }

        [HttpPost(Name = "AddOrderHistory")]
        public IActionResult Add(OrderHistory orderHistory)
        {
            _orderHistoryAccess.AddOrderHistory(orderHistory);
            return CreatedAtRoute("GetOrderHistoryById", new { orderHistoryId = orderHistory.OrderHistoryId }, orderHistory);
        }

        [HttpPut("{orderHistoryId}", Name = "UpdateOrderHistory")]
        public IActionResult Update(int orderHistoryId, OrderHistory orderHistory)
        {
            if (orderHistoryId != orderHistory.OrderHistoryId)
            {
                return BadRequest();
            }

            _orderHistoryAccess.UpdateOrderHistory(orderHistory);
            return NoContent();
        }

        [HttpDelete("{orderHistoryId}", Name = "DeleteOrderHistory")]
        public IActionResult Delete(int orderHistoryId)
        {
            _orderHistoryAccess.DeleteOrderHistory(orderHistoryId);
            return NoContent();
        }
    }
}
