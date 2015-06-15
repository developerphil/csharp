using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.ActionResult
{
    public class ExampleActionResult<T> : IHttpActionResult where T : class
    {
        private HttpRequestMessage _request;
        private string _version;
        private T _body;

        public ExampleActionResult(HttpRequestMessage request, string version, T body)
        {
            _request = request;
            _version = version;
            _body = body;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var msg = _request.CreateResponse(_body);
            msg.Headers.Add("XXX-OurVersion", _version);
            return Task.FromResult(msg);
        }
    }
}