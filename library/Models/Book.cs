using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string Name { get; set; } = "";

        [Display(Name = "גובה הספר")]
        public int Height { get; set; }

    }
}
