using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Payment")]
    public class Payment
    {
        [PrimaryKey] 
        public int PaymentId { get; set; }
        [Column] 
        public int OrderId { get; set; }
        [Column] 
        public string PaymentMethod { get; set; }
        [Column] 
        public decimal Amount { get; set; }
        [Column] 
        public DateTime PaymentDate { get; set; }
        [Association(ThisKey = nameof(OrderId), OtherKey = nameof(Order.OrderId))]
        public Order Order { get; set; }
    }
}
