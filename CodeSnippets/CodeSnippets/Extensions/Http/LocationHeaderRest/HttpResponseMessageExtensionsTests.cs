using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace CodeSnippets.Extensions.Http.LocationHeaderRest
{
    [TestFixture]
    public class HttpResponseMessageExtensionsTests
    {
        [Test]
        public void HttpResponseMessageExtensionsTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), "http://www.abc.com/a");

            var response = new HttpResponseMessage(HttpStatusCode.Created);

            /* Add location of the resource that was created */
            response.AddLocationHeader(request, 1);
        }
    }
}
