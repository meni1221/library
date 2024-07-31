using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LibraryModel
    {
        public LibraryModel()
        {
            Shelfs = new List<Shelf>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string Name { get; set; } = "";

        public List<Shelf> Shelfs { get; set; }
    }
}
