using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class TokenController : BaseApiController
    {
        private readonly IExampleRepository _exampleRepository;

        public TokenController(IExampleRepository exampleRepository) : base(exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        //Create a token if already registered user with api key and signature - clean up of old tokens need to be considered.
        public HttpResponseMessage Post([FromBody]TokenRequestModel model)
        {
            try
            {
                var user = _exampleRepository.GetApiUsers().FirstOrDefault(u => u.AppId == model.ApiKey);

                if (user != null)
                {
                    var secret = user.Secret;

                    // Simplistic implementation DO NOT USE
                    var key = Convert.FromBase64String(secret);
                    var provider = new System.Security.Cryptography.HMACSHA256(key);
                    // Compute Hash from API Key (NOT SECURE)
                    var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(user.AppId));
                    var signature = Convert.ToBase64String(hash);

                    if (signature == model.Signature)
                    {
                        var rawTokenInfo = string.Concat(user.AppId + DateTime.UtcNow.ToString("d"));
                        var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
                        var token = provider.ComputeHash(rawTokenByte);
                        var authToken = new AuthToken()
                        {
                            Token = Convert.ToBase64String(token),
                            Expiration = DateTime.UtcNow.AddDays(7),
                            ApiUser = user
                        };

                        if (_exampleRepository.Insert(authToken) && _exampleRepository.SaveAll())
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, CreateAuthModel(authToken));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        private AuthTokenModel CreateAuthModel(AuthToken authToken)
        {
            return new AuthTokenModel()
            {
                Token = authToken.Token,
                Expiration = authToken.Expiration
            };
        }

    }
}
