using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
namespace TestOperations
{
    public class CustomerDataAccess
    {
        private readonly string _connectionString;

        public CustomerDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllCustomer()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var customer in db.GetTable<Customer>().ToList())
                {
                    Console.WriteLine($"CustomerId: {customer.CustomerId}, FirstName: {customer.FirstName}, LastName: {customer.LastName}, Email: {customer.Email},  Phone: {customer.Phone},  Address: {customer.Address}");
                }
            }
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var customer in db.GetTable<Customer>())
                {
                    customers.Add(customer);
                }
            }

            return customers;
        }
        public void AddCustomer(Customer customer)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(customer);
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Customer>().FirstOrDefault(p => p.CustomerId == customerId);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(customer);
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Customer>().Delete(p => p.CustomerId == customerId);
            }
        }
    }
}