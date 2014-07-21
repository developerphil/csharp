using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CodeSnippets.LazyInitialization
{
    [TestFixture]
    public class LazyTests
    {
        /* For resource intensive constructors */

        /* http://bit.ly/pscslazy */

        [Test]
        public void LazyTest()
        {
            var lazyPerson = new Lazy<Person>(() => new Person("Person"));

            Debug.WriteLine("Running Test");

            var info = lazyPerson.Value.GetInfo();

            Debug.WriteLine(info);

            lazyPerson.Value.Name = "Phil";

        }
    }

    public class Person
    {
        public string Name { get; set; }

        public Person(string p1)
        {
            Debug.WriteLine("In constructor" + p1);
        }

        public string GetInfo()
        {
            return "Person Info";
        }
    }
}
