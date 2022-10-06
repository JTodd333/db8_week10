using Dapper.Contrib.Extensions;

namespace BookClubProject.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
