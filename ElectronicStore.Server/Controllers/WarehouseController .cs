using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseAccess _warehouseAccess;

        public WarehouseController(WarehouseAccess warehouseAccess)
        {
            _warehouseAccess = warehouseAccess;
        }

        [HttpGet("{warehouseId}", Name = "GetWarehouseById")]
        public ActionResult<Warehouse> GetById(int warehouseId)
        {
            var warehouse = _warehouseAccess.GetWarehouseById(warehouseId);
            if (warehouse == null)
            {
                return NotFound();
            }
            return warehouse;
        }

        [HttpGet(Name = "GetAllWarehouses")]
        public ActionResult<IEnumerable<Warehouse>> GetAll()
        {
            var warehouses = _warehouseAccess.GetAllWarehouse();
            return Ok(warehouses);
        }

        [HttpPost(Name = "AddWarehouse")]
        public IActionResult Add(Warehouse warehouse)
        {
            _warehouseAccess.AddWarehouse(warehouse);
            return CreatedAtRoute("GetWarehouseById", new { warehouseId = warehouse.WarehouseId }, warehouse);
        }

        [HttpPut("{warehouseId}", Name = "UpdateWarehouse")]
        public IActionResult Update(int warehouseId, Warehouse warehouse)
        {
            if (warehouseId != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            _warehouseAccess.UpdateWarehouse(warehouse);
            return NoContent();
        }

        [HttpDelete("{warehouseId}", Name = "DeleteWarehouse")]
        public IActionResult Delete(int warehouseId)
        {
            _warehouseAccess.DeleteWarehouse(warehouseId);
            return NoContent();
        }
    }
}
