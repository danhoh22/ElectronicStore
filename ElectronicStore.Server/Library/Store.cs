using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Store")]
    public class Store
    {
        [PrimaryKey] 
        public int StoreId { get; set; }
        [Column] 
        public string StoreName { get; set; }
        [Column] 
        public string Address { get; set; }
    }
}
