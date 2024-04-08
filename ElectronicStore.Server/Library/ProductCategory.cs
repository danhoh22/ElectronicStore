using LinqToDB.Mapping;

namespace Library
{
    [Table(Name = "ProductCategory")]
    public class ProductCategory
    {
        [PrimaryKey] 
        public int ProductCategoryId { get; set; }
        [Column] 
        public string ProductCategoryName { get; set; }
        public override string ToString()
        {
            return ProductCategoryName;
        }
    }
}
