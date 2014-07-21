using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class SpecialCharacters
    {
        [Test]
        public void SpecialCharactersExample()
        {
            /* Backslash to escape characters */

            var regex = new Regex(@"\(car\)\?");
            var result = regex.Match("(car)?");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);
        }

    }
}