using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeSnippets.Extensions.LamdaExpression
{
    public static class LambdaExpressionExtensions
    {
        public static PropertyInfo ToPropertyInfo(this LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            return memberExpression.Member as PropertyInfo;
        }
    }

    public class Map<TSource, TTarget> where TTarget : class, new()
    {
        public TSource Source { get; set; }

        public TTarget Target { get; set; }

        public Map(TSource source)
        {
            Source = source;
            Target = new TTarget();
        }

        public Map<TSource, TTarget> Populate<T>(Expression<Func<TTarget, T>> targetAccessor, Func<TSource, T> sourceValue)
        {
            var targetPropertyInfo = targetAccessor.ToPropertyInfo();
            targetPropertyInfo.SetValue(Target, sourceValue(Source));
            return this;
        }

    }

    [TestFixture]
    public class TestExpresions
    {
        [Test]
        public void WithExpressionReflection()
        {
            var map = new Map<UserModel, User>(new UserModel() {Name = "John", Surname = "Smith"});
            map.Populate(t => t.FullName, t => t.Name + " " + t.Surname);

            Assert.That(map.Target.FullName, Is.EqualTo("John Smith"));
        }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class User
    {
        public string FullName { get; set; }
    }
}
