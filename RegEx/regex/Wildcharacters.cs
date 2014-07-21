using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class Wildcharacters
    {
        // . is the wildcharacter (doesn't match \n (newline))

        [Test]
        public void WildcharactersTest()
        {
            var regex = new Regex("c.t");
            var result = regex.Match("cut");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);

        }

    }
}