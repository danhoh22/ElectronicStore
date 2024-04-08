using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "ShoppingCart")]
    public class ShoppingCart
    {
        [PrimaryKey] 
        public int ShoppingCartId { get; set; }
        [Column] 
        public int CustomerId { get; set; }
        [Column] 
        public int ProductId { get; set; }
        [Column] 
        public int Quantity { get; set; }
        [Column] 
        public decimal Price { get; set; }
        [Column] 
        public decimal TotalPrice { get; set; }
        [Association(ThisKey = nameof(ProductId), OtherKey = nameof(Product.ProductId))]
        public Product Product { get; set; }
        [Association(ThisKey = nameof(CustomerId), OtherKey = nameof(Customer.CustomerId))]
        public Customer Customer { get; set; }
    }
}
