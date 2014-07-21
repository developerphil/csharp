using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    [TestFixture]
    public class Repeatition
    {
        [Test]
        public void Repeat()
        {
            /*Regex are greedy by default*/

            var regex = new Regex("a*");
            var result = regex.Match("xaaaa");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);

            /* Group the pattern for repeatition still match 0* repeat */
            regex = new Regex("(car)*");
            result = regex.Match("van");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);

            /* Group the pattern for repeatition no match with plus*/
            regex = new Regex("(car)+");
            result = regex.Match("van");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.False);

            /* Group the pattern for repeatition and only match 1 to 3 times*/
            regex = new Regex("(car){1,3}");
            result = regex.Match("van carcarcar");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);
        }
    }
}