using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex.RegExPatterns
{
    [TestFixture]
    public class Decimal
    {
        [TestCase("10.00", true)]
        [TestCase("10.99", true)]
        [TestCase("1.99", true)]
        [TestCase("100.01", true)]
        [TestCase("1350.01", true)]
        [TestCase("10001.01", true)]
        [TestCase("10001.0", true)]
        [TestCase("10001.9", true)]
        [TestCase("10001", true)]
        [TestCase("10001.", false)]
        [TestCase("10001.123", false)]
        [TestCase("1.1234", false)]
        [TestCase("abc", false)]
        public void DecimalTest(string testString, bool result)
        {
            var regex = new Regex(@"^\d{1,9}(\.\d{1,2})?$");

            var isMatch = regex.IsMatch(testString);

            Assert.That(isMatch, Is.EqualTo(result));
        }
    }
}
