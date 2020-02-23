using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using Library.Data;
using Library.Data.Repositories;
using Library.Data.Repositories.Contracts;
using LibraryApi.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace LibraryApi
{
    public class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //register services here
            container.Register(() => new LibraryContext(), Lifestyle.Scoped);
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}