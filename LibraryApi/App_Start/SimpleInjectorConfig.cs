using System.Web.Http;
using System.Web.Mvc;

using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace LibraryApi
{ 
    public class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();

            //register services here

            container.RegisterWebApiControllers(new HttpConfiguration());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}