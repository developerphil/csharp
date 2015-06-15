using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using WebAPI.Filters;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interface;

namespace WebAPI.Controllers
{
    [RequireHttps]
    //[ExampleAuthorize]
    public class SecureExampleController : BaseApiController
    {
        private readonly IIdentityService _identityService;

        public SecureExampleController(IExampleRepository exampleRepository, IIdentityService identityService)
            : base(exampleRepository)
        {
            _identityService = identityService;
        }

        // GET api/values - GetData
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5 - GetData
        public HttpResponseMessage Get(int id)
        {
            var model = ExampleRepository.GetData();

            var urlHelper = new UrlHelper(Request);

            var username = _identityService.GetUser();

            if (username == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new ExampleApiModel { Id = model.Id, Data = username, Url = urlHelper.Link("Example", new { id }) });
        }

        // POST api/values - Add
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 - Update //Patch
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 - Delete
        public void Delete(int id)
        {
        }
    }
}