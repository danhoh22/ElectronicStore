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
    public class StoreAccess
    {
        private readonly string _connectionString;

        public StoreAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllShoppingCart()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var store in db.GetTable<Store>().ToList())
                {
                    Console.WriteLine($"StoreId: {store.StoreId}, StoreName: {store.StoreName}, Address: {store.Address}");
                }
            }
        }
        public List<Store> GetAllStore()
        {
            List<Store> stores = new List<Store>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var store in db.GetTable<Store>())
                {
                    stores.Add(store);
                }
            }

            return stores;
        }
        public void AddStore(Store store)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(store);
            }
        }

        public Store GetStoreById(int storeId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Store>().FirstOrDefault(p => p.StoreId == storeId);
            }
        }

        public void UpdateStore(Store store)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(store);
            }
        }

        public void DeleteStore(int storeId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Store>().Delete(p => p.StoreId == storeId);
            }
        }
    }
}