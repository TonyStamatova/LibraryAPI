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

        #region CREATE
        public void AddBook(Book book)
        {
            this.context.Books
                .Add(book);
        } 
        #endregion

        #region READ
        public async Task<Book> GetBookById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book[]> GetBooksByTitleAsync(string partOfTitle)
        {
            IQueryable<Book> query = context.Books
                .Where(b => b.Title.ToLower().Contains(partOfTitle.ToLower()))
                .Include(b => b.Author)
                .Include(b => b.KeyWords.Select(bkw => bkw.KeyWord));

            return await query.ToArrayAsync();
        }

        public async Task<Book[]> GetAllBooksByGenreAsync(Genre genre)
        {
            IQueryable<Book> query = context.Books
                .Where(b => b.Genre == genre)
                .Include(b => b.Author)
                .Include(b => b.KeyWords.Select(bkw => bkw.KeyWord));

            return await query.ToArrayAsync();
        }
        #endregion

        #region UPDATE
        #endregion

        #region DALETE
        public void DeleteBook(Book book)
        {
            this.context.Books
                .Remove(book);
        }
        #endregion
    }
}
