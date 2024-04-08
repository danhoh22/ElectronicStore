using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailAccess _orderDetailAccess;

        public OrderDetailController(OrderDetailAccess orderDetailAccess)
        {
            _orderDetailAccess = orderDetailAccess;
        }

        [HttpGet("{orderDetailId}", Name = "GetOrderDetailById")]
        public ActionResult<OrderDetail> GetById(int orderDetailId)
        {
            var orderDetail = _orderDetailAccess.GetOrderDetailById(orderDetailId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        [HttpGet(Name = "GetAllOrderDetails")]
        public ActionResult<IEnumerable<OrderDetail>> GetAll()
        {
            var orderDetails = _orderDetailAccess.GetAllOrderDetail();
            return Ok(orderDetails);
        }

        [HttpPost(Name = "AddOrderDetail")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            _orderDetailAccess.AddOrderDetail(orderDetail);
            return CreatedAtRoute("GetOrderDetailById", new { orderDetailId = orderDetail.OrderDetailId }, orderDetail);
        }

        [HttpPut("{orderDetailId}", Name = "UpdateOrderDetail")]
        public IActionResult Update(int orderDetailId, OrderDetail orderDetail)
        {
            if (orderDetailId != orderDetail.OrderDetailId)
            {
                return BadRequest();
            }

            _orderDetailAccess.UpdateOrderDetail(orderDetail);
            return NoContent();
        }

        [HttpDelete("{orderDetailId}", Name = "DeleteOrderDetail")]
        public IActionResult Delete(int orderDetailId)
        {
            _orderDetailAccess.DeleteOrderDetail(orderDetailId);
            return NoContent();
        }
    }
}
