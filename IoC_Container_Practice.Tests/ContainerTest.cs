using IoC_Container;
using Xunit;

namespace IoC_Container_Practice.Tests
{
    public class ContainerTest
    {
        [Fact]
        public void UnregisteredTypeThrowsException()
        {
            Container container = new Container();
            Assert.ThrowsAny<TypeNotRegisteredException>(() => { container.Resolve<UnregisteredClass>(); });
        }

        [Fact]
        public void RegisterNewType()
        {
            Container container = new Container();
            container.Register<IRegisteredClass, RegisteredClass>();
            var instance = container.Resolve<IRegisteredClass>();
            Assert.IsType<RegisteredClass>(instance);
        }

        [Fact]
        public void CanRegisterTransientType()
        {
            Container container = new Container();
            container.Register<IRegisteredClass, RegisteredClass>(LifeCycle.Transient);
            IRegisteredClass instance = container.Resolve<IRegisteredClass>();

            IRegisteredClass instance2 = container.Resolve<IRegisteredClass>();

            Assert.NotSame(instance, instance2);
        }

        [Fact]
        public void CanRegisterSingletonType()
        {
            Container container = new Container();
            container.Register<IRegisteredClass, RegisteredClass>(LifeCycle.Singleton);
            var instance = container.Resolve<IRegisteredClass>();

            var instance2 = container.Resolve<IRegisteredClass>();

            Assert.Same(instance, instance2);
        }

        public interface IRegisteredClass
        {
            int MyIndex { get; set; }
        }

        public class RegisteredClass : IRegisteredClass
        {
            private int _myIndex;
            public int MyIndex { get => _myIndex; set => _myIndex = value; }

            public RegisteredClass()
            {
                _myIndex = 1;
            }
        }

        public class RegisteredClass2 : IRegisteredClass
        {
            private int _myIndex;
            public int MyIndex { get => _myIndex; set => _myIndex = value; }

            public RegisteredClass2()
            {
                _myIndex = 2;
            }
        }

        public class UnregisteredClass
        {

        }
    }
}
