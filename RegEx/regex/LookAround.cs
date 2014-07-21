using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class LookAround
    {
        [Test]
        public void LookBehindPositive()
        {
            /* Positive look behind */

            var regex = new Regex(@"(?<=^)van");

            var isMatch = regex.IsMatch("vancar");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);

        }

        [Test]
        public void LookBehindNegivate()
        {
            /* Positive look behind */

            var regex = new Regex(@"(?<!^)van");

            var isMatch = regex.IsMatch("carvan");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);
        }

        [Test]
        public void LookAheadPositive()
        {
            var regex = new Regex(@"(\w+)(?=[:,;] )");

            var isMatch = regex.IsMatch("van; car: bus");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);

        }

        [Test]
        public void LookAheadNegative()
        {
            var regex = new Regex(@"(\w+(?!\w))(?![:,;])");

            var isMatch = regex.IsMatch("van:");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.False);

            regex = new Regex(@"(\w+(?!\w))(?![:,;])");

            isMatch = regex.IsMatch("van");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);

        }

    }


}