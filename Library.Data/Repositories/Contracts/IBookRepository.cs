using System.Threading.Tasks;

using Library.Data.Models;
using Library.Data.Models.Enumerations;

namespace Library.Data.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<bool> SaveChangesAsync();

        Task<Book[]> GetAllBooksByGenreAsync(Genre genre);

        void AddBook(Book book);
    }
}
