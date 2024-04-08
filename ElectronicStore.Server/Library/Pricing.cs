using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Pricing")]
    public class Pricing
    {
        [PrimaryKey] 
        public int PricingId { get; set; }
        [Column] 
        public int ProductId { get; set; }
        [Column] 
        public decimal Price { get; set; }
        [Column] 
        public DateTime StartDate { get; set; }
        [Column] 
        public DateTime EndDate { get; set; }
        [Association(ThisKey = nameof(ProductId), OtherKey = nameof(Product.ProductId))]
        public Product Product { get; set; }
    }
}
