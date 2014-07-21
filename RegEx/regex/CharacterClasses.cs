using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class CharacterClasses
    {
        /*
            [] Range
            \d \D (Digit or Not);
            \s \S (Whitespace or Not)
            \w \W (UniCode characters in english language or Not)
         */

        [Test]
        public void CharaterClass()
        {
            /* Charater classes more efficient e.g. [abc] a|b|c */

            var regex = new Regex(@"[abc]");
            var match = regex.Match("vancar");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void CharacterClassesWithRange()
        {
            var regex = new Regex(@"[0-9]");
            var match = regex.Match("van1car2");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(2));

            /* Not */

            Console.WriteLine("Not class [^0-9]");

            regex = new Regex(@"[^0-9]");
            match = regex.Match("van1car2");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(6));
        }

    }
}