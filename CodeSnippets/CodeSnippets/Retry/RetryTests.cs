using System;
using System.Net;
using System.Reflection.Emit;
using NUnit.Framework;

namespace CodeSnippets.Retry
{
    [TestFixture]
    public class RetryTests
    {
        [Test]
        public void RetryTest()
        {
            var client = new WebClient();
            Func<string, string> download = url => client.DownloadString(url);

            var data = download.Partial("http://microsoft.com").WithRetry();

            Console.WriteLine(data);

            Func<string, Func<string>> downloadCurry = download.Curry();

            data = downloadCurry("http://mircosoft.com").WithRetry();

            Console.WriteLine(data);
        }
    }

    public static class Extensions
    {
        public static T WithRetry<T>(this Func<T> action)
        {
            var result = default(T);

            var retryCount = 0;

            var successful = false;

            do
            {
                try
                {
                    result = action();
                    successful = true;
                }
                catch (WebException ex)
                {
                    retryCount++;
                }

            } while (retryCount < 3 && !successful);

            return result;
        }

        public static Func<TResult> Partial<TParam1, TResult>(this Func<TParam1, TResult> func, TParam1 parameter)
        {
            return () => func(parameter);
        }

        public static Func<TParam1, Func<TResult>> Curry<TParam1, TResult>(this Func<TParam1, TResult> func)
        {
            return parameter => () => func(parameter);
        }
    }
}
