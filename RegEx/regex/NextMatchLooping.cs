using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class NextMatchLooping
    {
        [Test]
        public void NextMatch()
        {
            var regex = new Regex("(car)?|van");
            var match = regex.Match("vancar");

            /* Notice option are always true so van is not matched with length */

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(5));
        }


    }
}