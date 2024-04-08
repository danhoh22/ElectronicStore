using Microsoft.AspNetCore.Mvc;
using TestOperations;
using Library;
namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryOptionController : ControllerBase
    {
        private readonly DeliveryOptionAccess _deliveryOptionAccess;

        public DeliveryOptionController(DeliveryOptionAccess deliveryOptionAccess)
        {
            _deliveryOptionAccess = deliveryOptionAccess;
        }

        [HttpGet("{deliveryOptionId}", Name = "GetDeliveryOptionById")]
        public ActionResult<DeliveryOption> GetById(int deliveryOptionId)
        {
            var deliveryOption = _deliveryOptionAccess.GetDeliveryOptionById(deliveryOptionId);
            if (deliveryOption == null)
            {
                return NotFound();
            }
            return deliveryOption;
        }

        [HttpGet(Name = "GetAllDeliveryOptions")]
        public ActionResult<IEnumerable<DeliveryOption>> GetAll()
        {
            var deliveryOptions = _deliveryOptionAccess.GetAllDeliveryOption();
            return Ok(deliveryOptions);
        }

        [HttpPost(Name = "AddDeliveryOption")]
        public IActionResult Add(DeliveryOption deliveryOption)
        {
            _deliveryOptionAccess.AddDeliveryOption(deliveryOption);
            return CreatedAtRoute("GetDeliveryOptionById", new { deliveryOptionId = deliveryOption.DeliveryOptionId }, deliveryOption);
        }

        [HttpPut("{deliveryOptionId}", Name = "UpdateDeliveryOption")]
        public IActionResult Update(int deliveryOptionId, DeliveryOption deliveryOption)
        {
            if (deliveryOptionId != deliveryOption.DeliveryOptionId)
            {
                return BadRequest();
            }

            _deliveryOptionAccess.UpdateDeliveryOption(deliveryOption);
            return NoContent();
        }

        [HttpDelete("{deliveryOptionId}", Name = "DeleteDeliveryOption")]
        public IActionResult Delete(int deliveryOptionId)
        {
            _deliveryOptionAccess.DeleteDeliveryOption(deliveryOptionId);
            return NoContent();
        }
    }
}
