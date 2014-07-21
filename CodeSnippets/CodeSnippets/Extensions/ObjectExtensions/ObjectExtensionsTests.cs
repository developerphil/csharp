using System;
using NUnit.Framework;

namespace CodeSnippets.Extensions.ObjectExtensions
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void ObjectExtensionTest()
        {
            const int obj1 = int.MaxValue;

            Console.WriteLine(obj1.ToJsonString());
        }

        [Test]
        public void ObjectExtensionTest2()
        {
            const int obj1 = int.MaxValue;

            Console.WriteLine(obj1.GetDescription());
        }
    }
}