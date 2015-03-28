using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSnippets.Extensions.LamdaExpression;
using NUnit.Framework;

namespace CodeSnippets.Linq
{
    [TestFixture]
    public class QueryProviderExampleTest
    {
        [Test]  
        public void Example()
        {
            var a = new List<string>() {"1", string.Empty};

            var source = new QueryProviderExample<string>(a);

            var query = from x in source
                        where x.Length > 0
                        where x != "12"
                        select x + "!";

            foreach (var b in query)
            {
                Console.WriteLine(b);
            }

        }
    }

    public class QueryProviderExample<T>
    {
        private readonly IEnumerable<T> _example;

        public QueryProviderExample(IEnumerable<T> example)
        {
            _example = example;
        }

        public QueryProviderExample<T> Where(Expression<Func<T, bool>> f)
        {
            var newlist = new List<T>();

            Func<T, bool> result = f.Compile();

            foreach (var item in _example)
            {
                if (result(item))
                {
                    newlist.Add(item);
                }
            }

            return new QueryProviderExample<T>(newlist);
        }

        public QueryProviderExample<TR> Select<TR>(Expression<Func<T, TR>> f)
        {
            var newlist = new List<TR>();
            var result = f.Compile();

            foreach (var item in _example)
            {
                newlist.Add(result(item));
            }

            return new QueryProviderExample<TR>(newlist);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _example.GetEnumerator();
        }

    }
}
