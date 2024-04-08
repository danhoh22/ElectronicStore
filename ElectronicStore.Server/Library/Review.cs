using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Review")]
    public class Review
    {
        [PrimaryKey] 
        public int ReviewId { get; set; }
        [Column] 
        public int ProductId { get; set; }
        [Column] 
        public int CustomerId { get; set; }
        [Column] 
        public int Rating { get; set; }
        [Column] 
        public string Comment { get; set; }
        [Column] 
        public DateTime ReviewDate { get; set; }
        [Association(ThisKey = nameof(ProductId), OtherKey = nameof(Product.ProductId))]
        public Product Product { get; set; }
        [Association(ThisKey = nameof(CustomerId), OtherKey = nameof(Customer.CustomerId))]
        public Customer Customer { get; set; }
    }
}
