using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly StoreAccess _storeAccess;

        public StoreController(StoreAccess storeAccess)
        {
            _storeAccess = storeAccess;
        }

        [HttpGet("{storeId}", Name = "GetStoreById")]
        public ActionResult<Store> GetById(int storeId)
        {
            var store = _storeAccess.GetStoreById(storeId);
            if (store == null)
            {
                return NotFound();
            }
            return store;
        }

        [HttpGet(Name = "GetAllStores")]
        public ActionResult<IEnumerable<Store>> GetAll()
        {
            var stores = _storeAccess.GetAllStore();
            return Ok(stores);
        }

        [HttpPost(Name = "AddStore")]
        public IActionResult Add(Store store)
        {
            _storeAccess.AddStore(store);
            return CreatedAtRoute("GetStoreById", new { storeId = store.StoreId }, store);
        }

        [HttpPut("{storeId}", Name = "UpdateStore")]
        public IActionResult Update(int storeId, Store store)
        {
            if (storeId != store.StoreId)
            {
                return BadRequest();
            }

            _storeAccess.UpdateStore(store);
            return NoContent();
        }

        [HttpDelete("{storeId}", Name = "DeleteStore")]
        public IActionResult Delete(int storeId)
        {
            _storeAccess.DeleteStore(storeId);
            return NoContent();
        }
    }
}
