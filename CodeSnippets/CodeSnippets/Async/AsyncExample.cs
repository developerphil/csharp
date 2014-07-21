using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeSnippets.Async
{
    public class AsyncExample
    {
        public async void RunAsync()
        {
            try
            {
                var w = new WebClient();
                var result = await w.DownloadStringTaskAsync("http://www.google.com/");

                //var req = (HttpWebRequest) WebRequest.Create("http://www.google.com");
                //Task<WebResponse> getResponseTask = Task.Factory.FromAsync<WebResponse>(req.BeginGetResponse, req.EndGetResponse, null);
                //var result = await getResponseTask;

                Console.WriteLine("Second");
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error handling the same, Task implementation wrappers up exceptions even if nested awaits.");
            }
        }

        public async void RunTwoAsync()
        {
            try
            {
                var w1 = new WebClient();
                var w2 = new WebClient();

                var task1 = w1.DownloadStringTaskAsync("http://www.google.com/");
                var task2 = w2.DownloadStringTaskAsync("http://www.bing.com/");

                string txt1 = await task1;
                string txt2 = await task2;

                Console.WriteLine("Second");
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error handling the same, Task implementation wrappers up exceptions even if nested awaits.");
            }
        }

        public async Task<string> RunAsyncTask()
        {
            
            var req = (HttpWebRequest) WebRequest.Create("http://www.google.com");
            Task<WebResponse> getResponseTask = Task.Factory.FromAsync<WebResponse>(
                req.BeginGetResponse, req.EndGetResponse, null);
            var response = (HttpWebResponse)await getResponseTask;

            var result = string.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            Console.WriteLine("Second");

            return result;
        }

        public void RunSync()
        {
            var w = new WebClient();
            var result = w.DownloadStringTaskAsync("http://www.google.com/");
            Console.WriteLine("Second");
        }

    }

    [TestFixture]
    public class AsyncExampleTests
    {
        [Test]
        public void AsyncExampleTest()
        {
            var ae = new AsyncExample();

            ae.RunAsync();

            Console.WriteLine("First");
            Thread.Sleep(10000);
        }

        [Test]
        public void AsyncTwoExampleTest()
        {
            var ae = new AsyncExample();

            ae.RunTwoAsync();

            Console.WriteLine("First");
            Thread.Sleep(10000);
        }

        [Test]
        public void SyncExampleTest()
        {
            var ae = new AsyncExample();

            ae.RunSync();

            Console.WriteLine("First");
            Thread.Sleep(10000);
        }


    }
}
