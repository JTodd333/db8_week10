using Dapper.Contrib.Extensions;

namespace BusinessCRUDDemo.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }
        public string description { get; set; } 


    }
}
