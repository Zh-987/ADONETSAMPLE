using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace ADONETExample.Utils
{
    public class CastleControllerFactory : DefaultControllerFactory
    {
        public IWindsorContainer Container { get; protected set; }

        public CastleControllerFactory(IWindsorContainer container)
        {
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.Container = container;
        }

       /* protected override IController GetControllerInstance(Type controllerType, RequestContext requestContext)
        {

            return Container.Resolve(controllerType) as IController;
        }
*/


        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;
            if(disposableController != null)
            {
                disposableController.Dispose();
            }
            /*base.ReleaseController(controller);*/
            Container.Release(controller);
        }
    }
}