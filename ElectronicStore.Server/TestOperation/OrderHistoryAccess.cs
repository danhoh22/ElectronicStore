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
    public class OrderHistoryAccess
    {
        private readonly string _connectionString;

        public OrderHistoryAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllOrderHistory()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var orderHistory in db.GetTable<OrderHistory>().LoadWith(req => req.OrderId).ToList())
                {
                    Console.WriteLine($"OrderHistoryId: {orderHistory.OrderHistoryId}, OrderId: {orderHistory.OrderId}, Status: {orderHistory.Status}, UpdateDate: {orderHistory.UpdateDate}");
                }
            }
        }
        public List<OrderHistory> GetAllOrderHistory()
        {
            List<OrderHistory> orderHistorys = new List<OrderHistory>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var orderHistory in db.GetTable<OrderHistory>())
                {
                    orderHistorys.Add(orderHistory);
                }
            }

            return orderHistorys;
        }
        public void AddOrderHistory(OrderHistory orderHistory)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(orderHistory);
            }
        }

        public OrderHistory GetOrderHistoryById(int orderHistoryId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<OrderHistory>().FirstOrDefault(p => p.OrderHistoryId == orderHistoryId);
            }
        }

        public void UpdateOrderHistory(OrderHistory orderHistory)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(orderHistory);
            }
        }

        public void DeleteOrderHistory(int orderHistoryId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<OrderHistory>().Delete(p => p.OrderHistoryId == orderHistoryId);
            }
        }
    }
}