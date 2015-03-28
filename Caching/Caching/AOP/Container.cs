using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Caching.AOP
{
    public static class Container
    {
        private static readonly WindsorContainer WindsorContainer = new WindsorContainer();

        static Container()
        {
            WindsorContainer.Register(Component.For<IMethod>().ImplementedBy<Methods>());
            WindsorContainer.Register(Component.For<CachingInterceptor>());

            //WindsorContainer.Register(Component.For().ImplementedBy());
            //WindsorContainer.Register(Component.For().ImplementedBy().Interceptors(InterceptorReference.ForType()).Anywhere);
        }

        public static WindsorContainer Instance { get { return WindsorContainer; } }

    }
}
