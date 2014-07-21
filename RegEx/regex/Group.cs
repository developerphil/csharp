using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class RegExGroup
    {
        [Test]
        public void GroupAndCommentsTest()
        {
            /* Inline comments  (?# cold)*/
            /* Comments modifier (?x)*/

            var regex = new Regex(@"(?mx)^ # regular expression to parse line item
                                    #1 month
                                    (January(?# cold)|February|March|April|May|June|July|August|September|October|November|December)\s+
                                    #2 day of month
                                    (\d{1,2}),\s+
                                    #3 year
                                    (\d{4})\s+
                                    #4 quantity
                                    (\d{1,4})\s+\$
                                    #5 whole dollars
                                    (\d{1,8})\.
                                    #6 pennies
                                    (\d{2})\s+
                                    #7 part number
                                    (\w+)\s*$");

            //Example Report line - Date  Quantity  Price  PartNumber
            var match = regex.Match("July 1, 2014    20    $2.56    X3548");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                foreach (var group in match.Groups)
                {
                    Console.WriteLine("   {0}", group);
                }

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));
        }
        
        [Test]
        public void GroupNameTest()
        {
            var regex = new Regex(@"(?mx)^ # regular expression to parse line item
                                    #1 month
                                    (?<month>January|February|March|April|May|June|July|August|September|October|November|December)\s+
                                    #2 day of month
                                    (?<day>\d{1,2}),\s+
                                    #3 year
                                    (?<year>\d{4})\s+
                                    #4 quantity
                                    (?<quantity>\d{1,4})\s+\$
                                    #5 whole dollars
                                    (?<dollars>\d{1,8})\.
                                    #6 pennies
                                    (?<pennies>\d{2})\s+
                                    #7 part number
                                    (?<partNumber>\w+)\s*$");

            //Example Report line - Date  Quantity  Price  PartNumber
            var match = regex.Match("July 1, 2014    20    $2.56    X3548");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                Console.WriteLine("Year - " + match.Groups["year"]);

                match = match.NextMatch();
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void GroupCapturesTest()
        {
            var regex = new Regex(@"car(van(...){3})");

            var match = regex.Match("carvanabcdefghi");

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

        [Test]
        public void GroupBackReferenceTest()
        {
            var regex = new Regex(@"(.)van\1");

            var match = regex.Match("avana");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));

            /* Group is back referenced */

            regex = new Regex(@"(\d\d)van\1");

            match = regex.Match("12van12");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));

            /* Group is back referenced Named Groups */

            Console.WriteLine("Named Groups Back Reference");

            regex = new Regex(@"(?<numbers>\d\d)van(?:\k<numbers>)");

            match = regex.Match("12van12");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1}", match.Index, match.Length);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void AtomicGroupTest()
        {
            /* Stops backtracking ?> */

            var regex = new Regex(@"(?>(car\s)+)van\s!$");

            var match = regex.Match("car car car van !");

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

            regex = new Regex(@"(?>(car\s)+)car\s!$");

            var isMatch = regex.IsMatch("car car car car !");

            Console.WriteLine("Will not match with atomic group because it can't back track (isMatch - {0})", isMatch);

            Assert.That(isMatch, Is.False);

        }

    }
}