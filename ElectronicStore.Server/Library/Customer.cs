using LinqToDB.Mapping;
namespace Library
{
    [Table(Name = "Customer")]
    public class Customer
    {
        [PrimaryKey] 
        public int CustomerId { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column] 
        public string Email { get; set; }
        [Column] 
        public string Phone { get; set; }
        [Column]
        public string Address { get; set; }
    }
}
