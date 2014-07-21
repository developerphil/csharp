using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeSnippets.Linq
{
    [TestFixture]
    public class Sorted
    {
        /* Also available SortedDictionary/Sorted List */

        /* http://bit.ly/pscssorted - Performance Discussion  */

        [Test]
        public void SortedSetTest()
        {
            var sortedSet = new SortedSet<int>();

            sortedSet.Add(4);
            sortedSet.Add(1);
            sortedSet.Add(3);
            sortedSet.Add(4);

            Assert.That(sortedSet.First(), Is.EqualTo(1));
            Assert.That(sortedSet.Count(), Is.EqualTo(3));

        }

        [Test]
        public void SortedSetWithComparerTest()
        {
            var sortedSet = new SortedSet<string>(new StringLengthComparer()) 
                                    {"stringone", "string", "anotherstring"};

            Assert.That(sortedSet.First(), Is.EqualTo("string"));
            Assert.That(sortedSet.Last(), Is.EqualTo("anotherstring"));

        }
    }

    public class StringLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
