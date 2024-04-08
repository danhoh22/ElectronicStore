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
    public class OrderDetailAccess
    {
        private readonly string _connectionString;

        public OrderDetailAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllOrderDetail()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var orderDetail in db.GetTable<OrderDetail>().LoadWith(req => req.OrderId).LoadWith(req => req.ProductId).ToList())
                {
                    Console.WriteLine($"OrderDetailId: {orderDetail.OrderDetailId}, OrderId: {orderDetail.OrderId}, ProductId: {orderDetail.ProductId}, Quantity: {orderDetail.Quantity}, Price: {orderDetail.Price}");
                }
            }
        }
        public List<OrderDetail> GetAllOrderDetail()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var orderDetail in db.GetTable<OrderDetail>())
                {
                    orderDetails.Add(orderDetail);
                }
            }

            return orderDetails;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(orderDetail);
            }
        }

        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<OrderDetail>().FirstOrDefault(p => p.OrderDetailId == orderDetailId);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(orderDetail);
            }
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<OrderDetail>().Delete(p => p.OrderDetailId == orderDetailId);
            }
        }
    }
}