using System;
using System.Reflection;
using NUnit.Framework;

namespace CodeSnippets.Extensions.InaccessibleTypes
{
    [TestFixture]
    public class InaccessibleTypesTests
    {
        [Test]
        public void InaccessibleTypesTest()
        {
            var type = typeof(InaccessibleTypes).GetNestedType("Inaccessible", BindingFlags.NonPublic);
            var obj = Activator.CreateInstance(type);

            Assert.That("INACCESSIBLE", Is.EqualTo(obj.StringUpper()));
        }
    }
}