using System;
using NUnit.Framework;

namespace CodeSnippets.Extensions.DateTimeExtensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void ToXmlDateTimeTest()
        {
            var dateTime = new DateTime(2014, 10, 24, 12, 10, 15, 0);
            Assert.That("2014-10-24T12:10:15Z", Is.EqualTo(dateTime.ToXmlDateTime()));
        }
    }
}