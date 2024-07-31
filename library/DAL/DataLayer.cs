using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DAL
{
    //קלאס שמייצג את שכבת הנתונים, יורש מקלאס בשם DbContext
    public class DataLayer : DbContext
    {
        //קונסטרקטור שמקבל מחרוזת חיבור ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();

            //להכניס נתונים בפעם הראשונה
            Seed();
        }

        //פונקציה להכנסת ערך ראשוני
        private void Seed()
        {
            //בדיקה האם ישנה ספריה
            if (Libraries.Count() > 0)
            {
                //במידה ואין ספריה 
                return;
            }
            //יצירת הספרייה הראשונה
            LibraryModel firstLib = new LibraryModel();
            //הכנסת שם הספריה הראשונה
            firstLib.Name = "הלכה";

            //הוספת הספריה הראשונה אל תוך רשימת הספריות
            Libraries.Add(firstLib);

            //בדיקה האם ישנו מדף
            if (Shelfs.Count() >0)
            {
                //במידה ואין מדף
                return ;
            }
            //יצירת המדף הראשון
            Shelf firstShelf = new Shelf();
            //הכנסת גובה המדף הראשונה
            firstShelf.Height = 13 ;

            //הוספת המדף הראשון אל תוך רשימת המדפים
            Shelfs.Add(firstShelf);

            //בדיקה האם יש ספרים 
            if (Books.Count() >0)
            {
                //במידה ואין ספר
                return ;
            }
            //יצירת הספר הראשון
            Book firstBook = new Book();
            //הכנסת שם הספר
            firstBook.Name = "חיי אדם";
            //הכנסת גובה הספר הראשונה
            firstBook.Height = 8 ;

            //הוספת הספר הראשון אל תוך רשימת הספרים
            Books.Add(firstBook);

            //שמירת הספריה הראשונה
            //ושמירת המדף הראשון
            //ושמירת הספר הראשון
            SaveChanges();
        }

        //יצירת רשימת הספריות
        public DbSet<LibraryModel> Libraries { get; set; }

        //יצירת רשימת המדפים
        public DbSet<Shelf> Shelfs { get; set; }

        //יצירת רשימת הספרים
        public DbSet<Book> Books { get; set; }
        //פונקציה שמחזירה את אפשרויות התחברות למסד נתונים
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
