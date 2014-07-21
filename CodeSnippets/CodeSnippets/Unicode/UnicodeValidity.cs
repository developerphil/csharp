using System.Globalization;
using NUnit.Framework;

namespace CodeSnippets.Unicode
{
    [TestFixture]
    public class UnicodeValidity
    {
        [Test]
        public void UnicodeValidityTest()
        {
            const char validCharater = 'q';

            var ucCategory = char.GetUnicodeCategory(validCharater);

            Assert.That(ucCategory == UnicodeCategory.OtherNotAssigned, Is.False);
        }

        [Test]
        public void UnicodeInvalidityTest()
        {
            const char invalidCharater = (char)888;

            var ucCategory = char.GetUnicodeCategory(invalidCharater);

            Assert.That(ucCategory == UnicodeCategory.OtherNotAssigned, Is.True);
        }

    }


    [TestFixture]
    public class UnicodeChecks
    {
        [Test]
        public void UnicodeChecksTest()
        {
            const char validCharater = '!';

            var ucCategory = char.GetUnicodeCategory(validCharater);

            Assert.That(ucCategory == UnicodeCategory.OtherPunctuation, Is.True);
        }


    }
}
