using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;

using AutoMapper;
using Library.Data.Models;
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
        public async Task<IHttpActionResult> Get(string title)
        {
            //TODO: get book by title

            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int genre = 0)
        {
            try
            {
                var books = await repo.GetAllBooksByGenreAsync((Genre)genre);
                var result = this.mapper.Map<IEnumerable<BookModel>>(books);

                return Ok(result);
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(BookModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = this.mapper.Map<Book>(model);
                    this.repo.AddBook(book);

                    if (await this.repo.SaveChangesAsync())
                    {
                        BookModel newModel = this.mapper.Map<BookModel>(book);
                        string location = Url.Route("GetBookByTitle", new { title = newModel.Title });

                        return Created(location, newModel);
                    }
                }
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest();
        }
    }
}