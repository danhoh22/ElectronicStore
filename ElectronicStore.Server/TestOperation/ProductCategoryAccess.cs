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
    public class ProductCategoryAccess
    {
        private readonly string _connectionString;

        public ProductCategoryAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllProductCategory()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var productCategory in db.GetTable<ProductCategory>().ToList())
                {
                    Console.WriteLine($"ProductCategoryId: {productCategory.ProductCategoryId}, ProductCategoryName: {productCategory.ProductCategoryName}");
                }
            }
        }
        public List<ProductCategory> GetAllProductCategory()
        {
            List<ProductCategory> productCategorys = new List<ProductCategory>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var productCategory in db.GetTable<ProductCategory>())
                {
                    productCategorys.Add(productCategory);
                }
            }

            return productCategorys;
        }
        public void AddProductCategory(ProductCategory productCategory)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(productCategory);
            }
        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<ProductCategory>().FirstOrDefault(p => p.ProductCategoryId == productCategoryId);
            }
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(productCategory);
            }
        }

        public void DeleteProductCategory(int productCategoryId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<ProductCategory>().Delete(p => p.ProductCategoryId == productCategoryId);
            }
        }
    }
}