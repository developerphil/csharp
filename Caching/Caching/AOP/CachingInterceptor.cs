using System;
using System.Runtime.Caching;
using Castle.Core.Internal;
using Castle.DynamicProxy;

namespace Caching.AOP
{
    public class CachingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                var cacheAttribute = invocation.MethodInvocationTarget.GetAttribute<CacheAttribute>();
                
                if (cacheAttribute == null || cacheAttribute.Disabled)
                {
                    invocation.Proceed();
                    return;
                }

                var cacheKey = String.Concat(invocation.TargetType.FullName, ".", invocation.Method.Name, "(",
                    String.Join(", ", invocation.Arguments), ")");
                if (MemoryCache.Default.Contains(cacheKey, cacheAttribute.CacheRegion))
                {
                    invocation.ReturnValue = MemoryCache.Default.Get(cacheKey, cacheAttribute.CacheRegion);
                    Console.WriteLine("Retrieve to Cache");
                }
                else
                {
                    invocation.Proceed();
                    MemoryCache.Default.Add(cacheKey, invocation.ReturnValue, new CacheItemPolicy());

                    Console.WriteLine("Add to Cache");
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}