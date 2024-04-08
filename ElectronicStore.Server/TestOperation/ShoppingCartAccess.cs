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
    public class ShoppingCartAccess
    {
        private readonly string _connectionString;

        public ShoppingCartAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllShoppingCart()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var shoppingCart in db.GetTable<ShoppingCart>().LoadWith(req => req.ProductId).LoadWith(req => req.CustomerId).ToList())
                {
                    Console.WriteLine($"ShoppingCartId: {shoppingCart.ShoppingCartId}, CustomerId: {shoppingCart.CustomerId}, ProductId: {shoppingCart.ProductId}, Quantity: {shoppingCart.Quantity}, Price: {shoppingCart.Price}, TotalPrice: {shoppingCart.TotalPrice}");
                }
            }
        }
        public List<ShoppingCart> GetAllShoppingCart()
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var shoppingCart in db.GetTable<ShoppingCart>())
                {
                    shoppingCarts.Add(shoppingCart);
                }
            }

            return shoppingCarts;
        }
        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(shoppingCart);
            }
        }

        public ShoppingCart GetShoppingCartById(int shoppingCartId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<ShoppingCart>().FirstOrDefault(p => p.ShoppingCartId == shoppingCartId);
            }
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(shoppingCart);
            }
        }

        public void DeleteShoppingCart(int shoppingCartId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<ShoppingCart>().Delete(p => p.ShoppingCartId == shoppingCartId);
            }
        }
    }
}