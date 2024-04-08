using Library;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestOperations
{
    public class ProductAccess
    {
        private readonly string _connectionString;
        
        public ProductAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllProduct()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var product in db.GetTable<Product>().LoadWith(req => req.ProductCategoryId).ToList())
                {
                    Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, ProductCategoryId: {product.ProductCategoryId}, Price: {product.Price}, StockQuantity: {product.StockQuantity}");
                }
            }
        }
        public List<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var product in db.GetTable<Product>().LoadWith(req => req.ProductCategory))
                {
                    products.Add(product);
                }
            }

            return products;
        }
        public void AddProduct(Product product)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(product);
            }
        }

        public Product GetProductById(int productId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Product>().FirstOrDefault(p => p.ProductId == productId);
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(product);
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Product>().Delete(p => p.ProductId == productId);
            }
        }
    }
}