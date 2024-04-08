using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentAccess _paymentAccess;

        public PaymentController(PaymentAccess paymentAccess)
        {
            _paymentAccess = paymentAccess;
        }

        [HttpGet("{paymentId}", Name = "GetPaymentById")]
        public ActionResult<Payment> GetById(int paymentId)
        {
            var payment = _paymentAccess.GetPaymentById(paymentId);
            if (payment == null)
            {
                return NotFound();
            }
            return payment;
        }

        [HttpGet(Name = "GetAllPayments")]
        public ActionResult<IEnumerable<Payment>> GetAll()
        {
            var payments = _paymentAccess.GetAllPayment();
            return Ok(payments);
        }

        [HttpPost(Name = "AddPayment")]
        public IActionResult Add(Payment payment)
        {
            _paymentAccess.AddPayment(payment);
            return CreatedAtRoute("GetPaymentById", new { paymentId = payment.PaymentId }, payment);
        }

        [HttpPut("{paymentId}", Name = "UpdatePayment")]
        public IActionResult Update(int paymentId, Payment payment)
        {
            if (paymentId != payment.PaymentId)
            {
                return BadRequest();
            }

            _paymentAccess.UpdatePayment(payment);
            return NoContent();
        }

        [HttpDelete("{paymentId}", Name = "DeletePayment")]
        public IActionResult Delete(int paymentId)
        {
            _paymentAccess.DeletePayment(paymentId);
            return NoContent();
        }
    }
}
