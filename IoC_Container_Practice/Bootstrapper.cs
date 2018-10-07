using IoC_Container;
using System.Web.Mvc;

namespace IoC_Container_Practice
{
    public static class Bootstrapper
    {
        public static IContainer Initialise()
        {
            var container = BuildContainer();

            DependencyResolver.SetResolver(new ContainerDependencyResolver(container));

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

        }
    }
}