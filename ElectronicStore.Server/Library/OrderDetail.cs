using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "OrderDetail")]
    public class OrderDetail
    {
        [PrimaryKey] 
        public int OrderDetailId { get; set; }
        [Column] 
        public int OrderId { get; set; }
        [Column] 
        public int ProductId { get; set; }
        [Column] 
        public int Quantity { get; set; }
        [Column] 
        public decimal Price { get; set; }
        [Association(ThisKey = nameof(ProductId), OtherKey = nameof(Product.ProductId))]
        public Product Product { get; set; }
        [Association(ThisKey = nameof(OrderId), OtherKey = nameof(Order.OrderId))]
        public Order Order { get; set; }
    }
}
