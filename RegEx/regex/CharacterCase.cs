using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class CharacterCase
    {
        [Test]
        public void CharacterCaseTest()
        {
            /*Case scoped to the first character*/

            var regex = new Regex("(?i:v)an");

            var isMatch = regex.IsMatch("Van");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);

            regex = new Regex("(?i:v)an");
            isMatch = regex.IsMatch("VaN");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.False);

        }
    }
}