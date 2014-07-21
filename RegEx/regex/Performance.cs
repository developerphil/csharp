using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{

    /*Testing tool for performance - Regex Fuzzer http://www.microsoft.com/en-us/download/details.aspx?id=20095*/

    [TestFixture]
    public class Performance
    {
        [Test]
        public void LazyCharacter()
        {
            /* Lazy character ? at the end of a group */

            /*Performance gain*/

            var regex = new Regex(@".*?z");

            var isMatch = regex.IsMatch("aaaaz");

            Console.WriteLine("(isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.True);
        }

        [Test]
        public void ExplicitNamedGroupsTest()
        {
            /* Explicit only named groups captured ?n modifier */

            var regex = new Regex(@"(?n)((?<word>\w+)\s)+(?<word>\w+)$");

            var match = regex.Match("car van bus");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("   {0}", group);

                    foreach (var capture in group.Captures)
                    {
                        Console.WriteLine("      {0}", capture);
                    }
                }

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(1));
        }
        
    }
}