using System.Threading.Tasks;

using Library.Data.Models;
using Library.Data.Models.Enumerations;

namespace Library.Data.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<Book[]> GetAllBooksByGenreAsync(Genre genre);
    }
}
