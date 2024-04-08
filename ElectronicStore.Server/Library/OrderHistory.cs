using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "OrderHistory")]
    public class OrderHistory
    {
        [PrimaryKey] 
        public int OrderHistoryId { get; set; }
        [Column] 
        public int OrderId { get; set; }
        [Column] 
        public string Status { get; set; }
        [Column] 
        public DateTime UpdateDate { get; set; }
        [Association(ThisKey = nameof(OrderId), OtherKey = nameof(Order.OrderId))]
        public Order Order { get; set; }
    }
}
