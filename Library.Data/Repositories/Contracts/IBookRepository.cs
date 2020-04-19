using System.Threading.Tasks;

using Library.Data.Models;
using Library.Data.Models.Enumerations;

namespace Library.Data.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<bool> SaveChangesAsync();

        #region CREATE
        void AddBook(Book book);
        #endregion

        #region READ
        Task<Book> GetBookById(int id);

        Task<Book[]> GetBooksByTitleAsync(string partOfTitle);

        Task<Book[]> GetAllBooksByGenreAsync(Genre genre);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void DeleteBook(Book book);
        #endregion
    }
}
