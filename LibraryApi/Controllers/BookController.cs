using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;

using Library.Data.Models.Enumerations;
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

        [HttpGet]
        public async Task<IHttpActionResult> Get(int genre = 0)
        {
            try
            {
                var result = await repo.GetAllBooksByGenreAsync((Genre)genre);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}