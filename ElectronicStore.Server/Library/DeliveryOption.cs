using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "DeliveryOption")]
    public class DeliveryOption
    {
        [PrimaryKey] 
        public int DeliveryOptionId { get; set; }
        [Column] 
        public string OptionName { get; set; }
        [Column] 
        public decimal Price { get; set; }
    }
}
