using Castle.Core;

namespace Caching.AOP
{
    [Interceptor(typeof(CachingInterceptor))]
    public class Methods : IMethod
    {
        [Cache]
        public virtual int DoWork()
        {
            return 1;
        }
    }
}
