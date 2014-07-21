using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class WordBoundaries
    {
        /* \b \B */
        // boundaries between \w word boundaries

        [Test]
        public void WordBoundariesTest()
        {
            var regex = new Regex(@"\b");
            var match = regex.Match("Test the word boundaries");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(8));

        }
    }
}