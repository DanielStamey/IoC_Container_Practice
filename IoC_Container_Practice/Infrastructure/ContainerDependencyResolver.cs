using IoC_Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace IoC_Container_Practice
{
    public class ContainerDependencyResolver : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public ContainerDependencyResolver(IContainer container)
        {
            this._container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                string controllername = requestContext.RouteData.Values["controller"].ToString();

                Type controllerType = Type.GetType(string.Format("IoC_Container_Practice.Controllers.{0}Controller", controllername), false, true);
                IController controller = _container.Resolve(controllerType) as IController;
                return controller;
            }
            catch
            {
                var defaultFactory = new DefaultControllerFactory();
                return defaultFactory.CreateController(requestContext, controllerName);
            }
            
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
