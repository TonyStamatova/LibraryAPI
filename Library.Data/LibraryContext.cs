using System.Data.Entity;

using Library.Data.EntityConfigurations;
using Library.Data.Models;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<KeyWord> KeyWords { get; set; }

        public DbSet<BookKeyWord> BooksKeyWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new KeyWordConfiguration());
            modelBuilder.Configurations.Add(new BookKeyWordConfiguration());
        }
    }
}
