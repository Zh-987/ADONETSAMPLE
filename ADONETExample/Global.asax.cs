using ADONETExample.Utils;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;

namespace ADONETExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoFacConfig.ConfigureContainer();
            NinjectModule regulations = new NinjectRegulations();
            var kernel = new StandardKernel(regulations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            var container = new WindsorContainer();
            container.Install(new CastleInstaller());

            var castleControllerFactory = new CastleControllerFactory(container);

            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            
        }
        protected void Application_Error()
        {

        }

    }
}
