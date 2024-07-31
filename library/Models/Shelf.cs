using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Shelf
    {
        public Shelf()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "גובה המדף")]
        public double Height { get; set; }
        public List<Book> Books { get; set; }
    }
}
