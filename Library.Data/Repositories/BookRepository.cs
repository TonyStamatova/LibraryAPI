using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Library.Data.Models;
using Library.Data.Models.Enumerations;
using Library.Data.Repositories.Contracts;

namespace Library.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext context;

        public BookRepository(LibraryContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<Book[]> GetAllBooksByGenreAsync(Genre genre)
        {
            IQueryable<Book> query = context.Books
                .Where(b => b.Genre == genre)
                .Include(b => b.Author)
                .Include(b => b.KeyWords.Select(bkw => bkw.KeyWord));

            return await query.ToArrayAsync();
        }

        public void AddBook(Book book)
        {
            this.context.Books
                .Add(book);
        }
    }
}
