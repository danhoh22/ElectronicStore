using LinqToDB.Mapping;
using System.Numerics;

namespace Library
{
    [Table(Name = "Product")]
    public class Product
    {
        [PrimaryKey] 
        public int ProductId { get; set; }
        [Column] 
        public string ProductName { get; set; }
        [Column] 
        public int ProductCategoryId { get; set; }

        [Association(ThisKey = nameof(ProductCategoryId), OtherKey = nameof(ProductCategory.ProductCategoryId))] 
        public ProductCategory ProductCategory { get; set; }
        [Column] 
        public decimal Price { get; set; }
        [Column] 
        public int StockQuantity { get; set; }
    }
}
