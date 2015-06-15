using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class ExampleController : BaseApiController
    {

        private UrlHelper _urlHelper;

        public ExampleController(IExampleRepository exampleRepository)
            : base(exampleRepository)
        {
        }

        // GET api/values - GetData
        public IEnumerable<string> Get()
        {
            //Paging pass back previous/next 

            return new[] { "value1", "value2" };
        }

        // GET api/values - GetData
        public IEnumerable<string> Get(int pagesize, int pageid)
        {
            //Paging pass back previous/next 

            return new[] { "value1", "value2" };
        }

        // GET api/values/5 - GetData
        public ExampleApiModel Get(int id)
        {
            var model = ExampleRepository.GetData();

            var urlHelper = new UrlHelper(Request);

            //CreateLink(_urlHelper.Link("Example", new {id = 1}), "self");
            //CreateLink(_urlHelper.Link("Example", new {id = 2}), "next");

            return new ExampleApiModel() { Id = model.Id, Data = model.Data, Url = urlHelper.Link("Example", new { id }) };
        }

        // POST api/values - Add [FromBody] a info from body can also a parameters from request
        public HttpResponseMessage Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error");
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/values/5 - Update
        public void Put(int id, [FromBody]string value)
        {
            //PUT the entire object
        }

        // PUT api/values/5 - Update
        public void Patch(int id, [FromBody]string value)
        {
            //PATCH the part of object
        }

        /*
          Instead of inferring by name use attributes
          
          [HttpPatch]
          public void PatchMethod(int id, [FromBody]string value)  
        */

        // DELETE api/values/5 - Delete
        public HttpResponseMessage Delete(int id)
        {
            // if not found return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public LinkModel CreateLink(string href, string rel, string method = "GET", bool isTemplated = false)
        {
            return new LinkModel()
            {
                Href = href,
                Rel = rel,
                Method = method,
                IsTemplated = isTemplated
            };
        }
    }
}