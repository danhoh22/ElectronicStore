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
    public class PaymentAccess
    {
        private readonly string _connectionString;

        public PaymentAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllPayment()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var payment in db.GetTable<Payment>().LoadWith(req => req.OrderId).ToList())
                {
                    Console.WriteLine($"PaymentId: {payment.PaymentId}, OrderId: {payment.OrderId}, PaymentMethod: {payment.PaymentMethod}, Amount: {payment.Amount}, PaymentDate: {payment.PaymentDate}");
                }
            }
        }
        public List<Payment> GetAllPayment()
        {
            List<Payment> payments = new List<Payment>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var payment in db.GetTable<Payment>())
                {
                    payments.Add(payment);
                }
            }

            return payments;
        }
        public void AddPayment(Payment payment)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(payment);
            }
        }

        public Payment GetPaymentById(int paymentId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Payment>().FirstOrDefault(p => p.PaymentId == paymentId);
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(payment);
            }
        }

        public void DeletePayment(int paymentId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Payment>().Delete(p => p.PaymentId == paymentId);
            }
        }
    }
}