using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class IfConditionAndOtherRegexGoodies
    {
        /*(?(predicate)true alternative|false alternative */

        /* if predicate run true regex if not run alternative */

        [Test]
        public void IfConditionTest()
        {
            var regex = new Regex(@"^(?(\d)\d{3}|[AB]{2})$");

            var isMatch = regex.IsMatch("233");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);

            isMatch = regex.IsMatch("AB");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);
        }


        /* Options And Modifiers - Ignore WhiteSpace, Case insensitive */
        /* Regex Complied */
        /* Regex Assembly */
        /* Regex right to left */
        /* Regex replace (delegates) */

    }
}