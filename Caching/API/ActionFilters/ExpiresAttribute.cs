using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace API.ActionFilters
{
    public class ExpiresAttribute : ActionFilterAttribute
    {
        public int Seconds { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            if (response.Content != null)
            {
                response.Content.Headers.Expires = DateTimeOffset.Now + TimeSpan.FromSeconds(Seconds);
                response.Headers.Vary.Add("Accept");
            }
            response.Headers.CacheControl = new CacheControlHeaderValue();
        }
    }
}