using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;

using AutoMapper;

using Library.Data.Models.Enumerations;
using Library.Data.Repositories.Contracts;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository repo;
        private readonly IMapper mapper;

        public BookController(IBookRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int genre = 0)
        {
            try
            {
                var books = await repo.GetAllBooksByGenreAsync((Genre)genre);
                var result = this.mapper.Map<BookModel>(books);

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