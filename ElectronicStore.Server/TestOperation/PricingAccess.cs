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
    public class PricingAccess
    {
        private readonly string _connectionString;

        public PricingAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllPricing()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var pricing in db.GetTable<Pricing>().LoadWith(req => req.ProductId).ToList())
                {
                    Console.WriteLine($"PricingId: {pricing.PricingId}, ProductId: {pricing.ProductId}, Price: {pricing.Price}, StartDate: {pricing.StartDate}, EndDate: {pricing.EndDate}");
                }
            }
        }
        public List<Pricing> GetAllPricing()
        {
            List<Pricing> pricings = new List<Pricing>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var pricing in db.GetTable<Pricing>())
                {
                    pricings.Add(pricing);
                }
            }

            return pricings;
        }
        public void AddPricing(Pricing pricing)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(pricing);
            }
        }

        public Pricing GetPricingById(int pricingId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Pricing>().FirstOrDefault(p => p.PricingId == pricingId);
            }
        }

        public void UpdatePricing(Pricing pricing)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(pricing);
            }
        }

        public void DeletePricing(int pricingId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Pricing>().Delete(p => p.PricingId == pricingId);
            }
        }
    }
}