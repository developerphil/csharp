using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Filters
{

    //OAuth look at DotNetOpenAuth makes third parties allow access to your api http://dotnetopenauth.net

    //Basic Authentication
    //Header on request base64 encode on iso-8859-1 e.g. Authorization: Basic cGhpbDpwYXNzd29yZA==
    public class ExampleAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleAuthorizeAttribute(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            /*const string APIKEYNAME = "apikey";
            const string TOKENNAME = "token";

            var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            if (!string.IsNullOrWhiteSpace(query[APIKEYNAME]) && !string.IsNullOrWhiteSpace(query[TOKENNAME]))
            {
                var apikey = query[APIKEYNAME];
                var token = query[TOKENNAME];

                var authToken = _exampleRepository.GetAuthToken(token);

                if (authToken != null && authToken.ApiUser.AppId == apikey && authToken.Expiration > DateTime.UtcNow)
                {
                    if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    {
                        return;
                    }

                    var authHeader = actionContext.Request.Headers.Authorization;

                    if (authHeader != null)
                    {
                        if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                            !string.IsNullOrWhiteSpace(authHeader.Parameter))
                        {
                            var rawCredentials = authHeader.Parameter;
                            var encoding = Encoding.GetEncoding("iso-8859-1");
                            var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
                            var split = credentials.Split(':'); //make not valid in password :
                            var username = split[0];
                            var password = split[1];

                            if (AuthenticateUser(username, password))
                            {
                                var principal = new GenericPrincipal(new GenericIdentity(username), null);
                                Thread.CurrentPrincipal = principal;
                                return;
                            }
                        }
                    }
                }
            }

            HandleUnauthorized(actionContext);*/
        }

        private bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='Example' location='http://localhost/account/login'");
        }
    }
}