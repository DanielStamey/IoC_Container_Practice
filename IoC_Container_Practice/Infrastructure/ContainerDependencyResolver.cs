using IoC_Container;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IoC_Container_Practice
{
    public class ContainerDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public ContainerDependencyResolver(IContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}
