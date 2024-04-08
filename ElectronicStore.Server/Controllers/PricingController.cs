using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly PricingAccess _pricingAccess;

        public PricingController(PricingAccess pricingAccess)
        {
            _pricingAccess = pricingAccess;
        }

        [HttpGet("{pricingId}", Name = "GetPricingById")]
        public ActionResult<Pricing> GetById(int pricingId)
        {
            var pricing = _pricingAccess.GetPricingById(pricingId);
            if (pricing == null)
            {
                return NotFound();
            }
            return pricing;
        }

        [HttpGet(Name = "GetAllPricings")]
        public ActionResult<IEnumerable<Pricing>> GetAll()
        {
            var pricings = _pricingAccess.GetAllPricing();
            return Ok(pricings);
        }

        [HttpPost(Name = "AddPricing")]
        public IActionResult Add(Pricing pricing)
        {
            _pricingAccess.AddPricing(pricing);
            return CreatedAtRoute("GetPricingById", new { pricingId = pricing.PricingId }, pricing);
        }

        [HttpPut("{pricingId}", Name = "UpdatePricing")]
        public IActionResult Update(int pricingId, Pricing pricing)
        {
            if (pricingId != pricing.PricingId)
            {
                return BadRequest();
            }

            _pricingAccess.UpdatePricing(pricing);
            return NoContent();
        }

        [HttpDelete("{pricingId}", Name = "DeletePricing")]
        public IActionResult Delete(int pricingId)
        {
            _pricingAccess.DeletePricing(pricingId);
            return NoContent();
        }
    }
}
