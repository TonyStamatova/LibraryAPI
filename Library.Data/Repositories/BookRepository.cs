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

        public async Task<Book[]> GetAllBooksByGenreAsync(string genre = "other")
        {
            Enum.TryParse(genre, true, out Genre genreEnum);

            if (genreEnum == Genre.Other)
            {
                throw new ArgumentException("There are no records for books of this genre.");
            }

            IQueryable<Book> query = context.Books
                .Where(b => b.Genre == genreEnum);

            return await query.ToArrayAsync();
        }
    }
}
