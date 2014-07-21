using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodeSnippets.Tuples
{
    [TestFixture]
    public class TuplesExamples
    {
        [Test]
        public void TuplesExampleTest()
        {
            var t1 = new Tuple<int, string>(1, "example1");

            Assert.That(t1.Item1, Is.EqualTo(1));
            Assert.That(t1.Item2, Is.EqualTo("example1"));

            var t2 = Tuple.Create(1, "example1");

            //value comparison reference with not == will not be equal 
            Assert.That(t1.Equals(t2));

        }

        [Test]
        public void UsingTupleToCreateACompositeKeyForADictionary()
        {
           var d1 = new SortedDictionary<Tuple<int, string>, string>
           {
               {Tuple.Create(1, "z"), "value1"},
               {Tuple.Create(1, "a"), "value2"},
               {Tuple.Create(2, "a"), "value3"}
           };

           Assert.That(d1[new Tuple<int, string>(1, "a")], Is.EqualTo("value2"));
        }
    }
}
