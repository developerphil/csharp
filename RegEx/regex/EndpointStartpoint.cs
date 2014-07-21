using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace regex
{
    public class EndpointStartpoint
    {

        [Test]
        public void EndpointAnchorsSingleLineStart()
        {
            /* Line starts \A ^*/

            Console.WriteLine(@"Regex \Avan");

            var regex = new Regex(@"\Avan");
            var match = regex.Match("vancar");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));

            Console.WriteLine("Regex ^van");

            regex = new Regex(@"^van");
            match = regex.Match("vancar");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));

        }

        [Test]
        public void EndpointAnchorsMultiLineStart()
        {
            /* New line taken into account with (m?) modifier (effect all regex even if there are alternatives)*/

            Console.WriteLine(@"Regex (?m)^van");

            var regex = new Regex(@"(?m)^van");
            var match = regex.Match("van\ncar\nvan");

            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(2));

            /* Scope (m?) modifier*/

            Console.WriteLine(@"Regex (?m:^van)|^car");

            regex = new Regex(@"(?m:^van)|^car");
            match = regex.Match("van\ncar\nvan");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(2));

        }

        [Test]
        public void EndpointAnchorsSingleLineEnd()
        {
            /* \Z \z $ (\Z not effected by the m?) (\z will not match \n)  */

            Console.WriteLine(@"Regex car$");

            var regex = new Regex(@"car$");
            var match = regex.Match("vancar");
            var count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(1));

            Console.WriteLine(@"Regex car\Z");

            regex = new Regex(@"car\Z");
            match = regex.Match("vancar\n");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();

                count++;
            }

            Assert.That(count, Is.EqualTo(1));

            Console.WriteLine(@"Regex car\z");

            regex = new Regex(@"car\z");
            match = regex.Match("vancar\n");

            count = 0;

            while (match.Success)
            {
                Console.WriteLine("Index start : {0} | length : {1} | success : {2}", match.Index, match.Length, match.Success);

                match = match.NextMatch();
                count++;
            }

            Assert.That(count, Is.EqualTo(0));

        }
    }
}