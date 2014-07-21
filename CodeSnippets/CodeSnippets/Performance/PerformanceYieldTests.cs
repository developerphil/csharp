using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeSnippets.Performance
{
    [TestFixture]
    public class PerformanceYieldTests
    {
        [Test]
        public void PerformanceYieldTest()
        {
            /* without yield all the numbers array would be looped through */

            var numbers = new[] {3, 4, 7, 5, 10};

            foreach (var number in numbers.Find(IsOdd).Take(2))
            {
                Console.WriteLine(number);
            }
        }

        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

    }

    public static class Extensions
    {
        public static IEnumerable<int> Find(this IEnumerable<int> collection, Func<int, bool> test)
        {
            foreach (var number in collection)
            {
                Console.WriteLine("Testing {0}", number);
                if (test(number))
                {
                    yield return number;
                }
            }
        }
    }


}
