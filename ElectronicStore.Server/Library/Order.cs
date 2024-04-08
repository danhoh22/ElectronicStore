using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Order")]
    public class Order
    {
        [PrimaryKey] 
        public int OrderId { get; set; }
        [Column] 
        public int CustomerId { get; set; }
        [Column] 
        public DateTime OrderDate { get; set; }
        [Column] 
        public int DeliveryOptionId { get; set; }
        [Column] 
        public int StoreId { get; set; }
        [Column] 
        public decimal TotalAmount { get; set; }
        [Association(ThisKey = nameof(CustomerId), OtherKey = nameof(Customer.CustomerId))]
        public Customer Customer { get; set; }
        [Association(ThisKey = nameof(DeliveryOptionId), OtherKey = nameof(DeliveryOption.DeliveryOptionId))]
        public DeliveryOption DeliveryOption { get; set; }
        [Association(ThisKey = nameof(StoreId), OtherKey = nameof(Store.StoreId))]
        public Store Store { get; set; }
    }
}
