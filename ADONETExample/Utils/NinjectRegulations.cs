using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADONETExample.Models;
using ADONETExample.Repository;
using Ninject.Modules;

namespace ADONETExample.Utils
{
    public class NinjectRegulations : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeRepository>().To<HomeRepository>().WithConstructorArgument("dbEntities", new MyMusicDBEntities());
        }
    }
}