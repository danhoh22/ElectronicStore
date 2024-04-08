using Microsoft.AspNetCore.Mvc;
using TestOperations;
using Library;
namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDataAccess _customerAccess;

        public CustomerController(CustomerDataAccess customerAccess)
        {
            _customerAccess = customerAccess;
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public ActionResult<Customer> GetById(int customerId)
        {
            var customer = _customerAccess.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _customerAccess.GetAllCustomer();
            return Ok(customers);
        }

        [HttpPost(Name = "AddCustomer")]
        public IActionResult Add(Customer customer)
        {
            _customerAccess.AddCustomer(customer);
            return CreatedAtRoute("GetCustomerById", new { customerId = customer.CustomerId }, customer);
        }

        [HttpPut("{customerId}", Name = "UpdateCustomer")]
        public IActionResult Update(int customerId, Customer customer)
        {
            if (customerId != customer.CustomerId)
            {
                return BadRequest();
            }

            _customerAccess.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{customerId}", Name = "DeleteCustomer")]
        public IActionResult Delete(int customerId)
        {
            _customerAccess.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
