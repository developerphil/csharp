using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace regex
{
     /* 
       http://www.regexbuddy.com/ 
       http://www.powergrep.com/
     */

    [TestFixture]
    public class Alternatives
    {
        [Test]
        public void Alternation()
        {
            /*Left match first alternative are checked in order*/

            var regex = new Regex("car|van|bus");
            var result = regex.Match("van");
            
            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);

            regex = new Regex("carcarcar|carcar|car");
            result = regex.Match("carcar");

            Console.WriteLine("Index start : {0} | length : {1}", result.Index, result.Length);

            Assert.That(result.Success, Is.True);
        }

       

    }
}
