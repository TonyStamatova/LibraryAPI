using System.Web.Http;

namespace LibraryApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("The LibraryAPI is ready to take your requests...");
        }
    }
}