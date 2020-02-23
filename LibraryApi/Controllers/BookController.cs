using System;
using System.Threading.Tasks;
using System.Web.Http;

using Library.Data.Repositories.Contracts;

namespace LibraryApi.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository repo;

        public BookController(IBookRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await repo.GetAllBooksByGenreAsync();
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}