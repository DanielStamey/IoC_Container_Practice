using IoC_Container;
using IoC_Container_Practice.Controllers;
using IoC_Container_Practice.Models;
using System.Web.Mvc;

namespace IoC_Container_Practice
{
    public static class Bootstrapper
    {
        public static IContainer Initialise()
        {
            var container = BuildContainer();
            
            ControllerBuilder.Current.SetControllerFactory(new ContainerDependencyResolver(container));

            return container;
        }

        private static IContainer BuildContainer()
        {
            var container = new Container();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(Container container)
        {
            container.Register<ProteinTrackerController, ProteinTrackerController>();
            container.Register<IProteinTrackingService, ProteinTrackingService>();
            container.Register<IProteinRepository, ProteinRepository>();
        }
    }
}