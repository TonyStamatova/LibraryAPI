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
            try
            {
                var books = await repo.GetBooksByTitleAsync(title);
                var result = this.mapper.Map<IEnumerable<BookModel>>(books);

                return Ok(result);
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }
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
                if (await this.repo.GetBooksByTitleAsync(model.Title) != null)
                {
                    ModelState.AddModelError("Title", "This book is already in the library");
                }

                if (ModelState.IsValid)
                {
                    Book book = this.mapper.Map<Book>(model);
                    this.repo.AddBook(book);

                    if (await this.repo.SaveChangesAsync())
                    {
                        BookModel newModel = this.mapper.Map<BookModel>(book);
                        string location = Url.Route("GetBooksByTitle", new { title = newModel.Title });

                        return Created(location, newModel);
                    }
                }
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, BookModel model)
        {
            try
            {
                var book = this.repo.GetBookById(id);

                if (book != null)
                {
                    return NotFound();
                }

                this.mapper.Map(model, book);

                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(this.mapper.Map<BookModel>(book));
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (SqlException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}