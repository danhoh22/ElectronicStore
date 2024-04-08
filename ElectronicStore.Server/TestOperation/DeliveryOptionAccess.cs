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
    public class DeliveryOptionAccess
    {
        private readonly string _connectionString;

        public DeliveryOptionAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllDeliveryOption()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var deliveryOption in db.GetTable<DeliveryOption>().ToList())
                {
                    Console.WriteLine($"DeliveryOptionId: {deliveryOption.DeliveryOptionId}, OptionName: {deliveryOption.OptionName}, Price: {deliveryOption.Price}");
                }
            }
        }
        public List<DeliveryOption> GetAllDeliveryOption()
        {
            List<DeliveryOption> deliveryOptions = new List<DeliveryOption>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var deliveryOption in db.GetTable<DeliveryOption>())
                {
                    deliveryOptions.Add(deliveryOption);
                }
            }

            return deliveryOptions;
        }
        public void AddDeliveryOption(DeliveryOption deliveryOption)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(deliveryOption);
            }
        }

        public DeliveryOption GetDeliveryOptionById(int deliveryOptionId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<DeliveryOption>().FirstOrDefault(p => p.DeliveryOptionId == deliveryOptionId);
            }
        }

        public void UpdateDeliveryOption(DeliveryOption deliveryOption)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(deliveryOption);
            }
        }

        public void DeleteDeliveryOption(int deliveryOptionId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<DeliveryOption>().Delete(p => p.DeliveryOptionId == deliveryOptionId);
            }
        }
    }
}