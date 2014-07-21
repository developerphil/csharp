using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeSnippets.Linq
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void FilterTest()
        {
            var list = new List<string> {"Las Vegas", "New York", "Lisbon", "Berlin"};

            var filteredList = list.Filter(item => item.StartsWith("L"));

            Assert.That(filteredList.Count(), Is.EqualTo(2));
        }

    }

    public static class FilterExtension
    {
        public static IEnumerable<string> Filter(this IEnumerable<string> list, Predicate<string> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

    }


}
