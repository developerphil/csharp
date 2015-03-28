using Caching.AOP;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace Caching.Test
{
    [TestFixture]
    public class CacheAttributeTest
    {
        [Test]
        public void TestCacheAttribute()
        {
            var methods = Container.Instance.Resolve<IMethod>();

            methods.DoWork();
            methods.DoWork();
        }

    }
}
