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
    public class OrderAccess
    {
        private readonly string _connectionString;

        public OrderAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllOrder()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var order in db.GetTable<Order>().LoadWith(req => req.DeliveryOptionId).LoadWith(req => req.StoreId).LoadWith(req => req.CustomerId))
                {
                    Console.WriteLine($"OrderId: {order.OrderId}, CustomerId: {order.CustomerId}, OrderDate: {order.OrderDate}, DeliveryOptionId: {order.DeliveryOptionId}, StoreId: {order.StoreId}, TotalAmount: {order.TotalAmount}");
                }
            }
        }
        public List<Order> GetAllOrder()
        {
            List<Order> orders = new List<Order>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var order in db.GetTable<Order>())
                {
                    orders.Add(order);
                }
            }

            return orders;
        }
            public void AddOrder(Order order)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(order);
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Order>().FirstOrDefault(p => p.OrderId == orderId);
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(order);
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Order>().Delete(p => p.OrderId == orderId);
            }
        }
    }
}