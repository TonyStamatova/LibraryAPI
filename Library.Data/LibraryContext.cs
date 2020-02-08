using System.Data.Entity;

using Library.Data.Models;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }        
    }
}
