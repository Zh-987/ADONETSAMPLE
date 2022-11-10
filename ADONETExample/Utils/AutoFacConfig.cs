using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADONETExample.Models;
using ADONETExample.Repository;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;

namespace ADONETExample.Utils
{
    public class AutoFacConfig 
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            /*builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithParameter("dbcontext",new MyMusicDBEntities());*/
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithParameters(new List<Parameter> { new NamedParameter ("dbcontext", new MyMusicDBEntities()), new NamedParameter("conString", "vugbhdinjoa") });
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithProperty("dbcontext", new MyMusicDBEntities());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}