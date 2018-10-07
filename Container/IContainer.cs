using System;
using System.Collections.Generic;

namespace IoC_Container
{
    public interface IContainer
    {
        void Register<TTypeToResolve, TConcrete>();
        void Register<TTypeToResolve, TConcrete>(LifeCycle lifeCycle);
        TTypeToResolve Resolve<TTypeToResolve>();
        object Resolve(Type typeToResolve);
        IEnumerable<object> ResolveAll(Type typeToResolve);
    }
}
