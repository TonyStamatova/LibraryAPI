using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using Library.Data;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

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

            container.RegisterWebApiControllers(new HttpConfiguration(), Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}