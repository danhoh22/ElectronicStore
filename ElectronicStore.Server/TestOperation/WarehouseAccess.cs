using Library;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOperations
{
    public class WarehouseAccess
    {
        private readonly string _connectionString;

        public WarehouseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllWarehouse()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var warehouse in db.GetTable<Warehouse>().LoadWith(req => req.StoreId).ToList())
                {
                    Console.WriteLine($"WarehouseId: {warehouse.WarehouseId}, StoreId: {warehouse.StoreId}, Capacity: {warehouse.Capacity}");
                }
            }
        }
        public List<Warehouse> GetAllWarehouse()
        {
            List<Warehouse> warehouses = new List<Warehouse>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var warehouse in db.GetTable<Warehouse>())
                {
                    warehouses.Add(warehouse);
                }
            }

            return warehouses;
        }
        public void AddWarehouse(Warehouse warehouse)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(warehouse);
            }
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Warehouse>().FirstOrDefault(p => p.WarehouseId == warehouseId);
            }
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(warehouse);
            }
        }

        public void DeleteWarehouse(int warehouseId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Warehouse>().Delete(p => p.WarehouseId == warehouseId);
            }
        }
    }
}