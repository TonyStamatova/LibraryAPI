using System.Web.Http;

using AutoMapper;

using Library.Data;
using Library.Data.Repositories;
using Library.Data.Repositories.Contracts;
using LibraryApi.Models.MappingProfiles;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;

namespace LibraryApi
{
    public class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            #region service registration
            container.Register(() => new LibraryContext(), Lifestyle.Scoped);

            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookProfile());
            });

            container.RegisterInstance(config.CreateMapper()); 
            #endregion

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}