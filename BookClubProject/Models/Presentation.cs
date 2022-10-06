using Dapper.Contrib.Extensions;

namespace BookClubProject.Models
{

    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int id { get; set; }
        public int PersonId { get; set; }
        public DateTime PresentationDate { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string Genre { get; set; }

    }
}
