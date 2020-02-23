using System.Threading.Tasks;

using Library.Data.Models;

namespace Library.Data.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<Book[]> GetAllBooksByGenreAsync(string genre = "fiction");
    }
}
