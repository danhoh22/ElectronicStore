using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "Warehouse")]
    public class Warehouse
    {
        [PrimaryKey] 
        public int WarehouseId { get; set; }
        [Column] 
        public int StoreId { get; set; }
        [Column] 
        public int Capacity { get; set; }
        [Association(ThisKey = nameof(StoreId), OtherKey = nameof(Store.StoreId))]
        public Store Store { get; set; }
    }
}
