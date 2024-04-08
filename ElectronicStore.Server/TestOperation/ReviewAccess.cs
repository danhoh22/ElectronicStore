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
    public class ReviewAccess
    {
        private readonly string _connectionString;

        public ReviewAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void PrintAllReview()
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                Console.WriteLine("Список всех клиентов:");
                foreach (var review in db.GetTable<Review>().LoadWith(req => req.ProductId).LoadWith(req => req.CustomerId).ToList())
                {
                    Console.WriteLine($"ReviewId: {review.ReviewId}, ProductId: {review.ProductId}, CustomerId: {review.CustomerId}, Rating: {review.Rating}, Comment: {review.Comment}, ReviewDate: {review.ReviewDate}");
                }
            }
        }
        public List<Review> GetAllReview()
        {
            List<Review> reviews = new List<Review>();

            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                foreach (var review in db.GetTable<Review>())
                {
                    reviews.Add(review);
                }
            }

            return reviews;
        }
        public void AddReview(Review review)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Insert(review);
            }
        }

        public Review GetReviewById(int reviewId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                return db.GetTable<Review>().FirstOrDefault(p => p.ReviewId == reviewId);
            }
        }

        public void UpdateReview(Review review)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.Update(review);
            }
        }

        public void DeleteReview(int reviewId)
        {
            using (var db = new DataConnection(new DataOptions().UsePostgreSQL(_connectionString)))
            {
                db.GetTable<Review>().Delete(p => p.ReviewId == reviewId);
            }
        }
    }
}