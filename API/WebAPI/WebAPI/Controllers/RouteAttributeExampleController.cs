using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/attribute")]
    public class RouteAttributeExampleController : BaseApiController
    {
        public RouteAttributeExampleController(IExampleRepository exampleRepository)
            : base(exampleRepository)
        {
        }

        // GET api/values - GetData
        [Route("")]
        [EnableCors("*", "*", "*")]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5 - GetData
        [Route("{id}")]
        public ExampleApiModel Get(int id)
        {
            var model = ExampleRepository.GetData();

            return new ExampleApiModel() { Id = model.Id, Data = model.Data };
        }

        //Add name for links e.g. urlHelper.Link("Example", ...
        [Route("~/api/attr/{id}", Name="AnotherGet")]
        [HttpGet]
        public ExampleApiModel AnotherGet(int id)
        {
            var model = ExampleRepository.GetData();

            return new ExampleApiModel() { Id = model.Id, Data = model.Data };
        }

        //Add name for links e.g. urlHelper.Link("Example", ...
        [Route("~/api/exampleget/{id}", Name = "AnotherExampleGet")]
        [HttpGet]
        public IHttpActionResult AnotherExampleGet(int id)
        {
            var model = ExampleRepository.GetData();

            return ExampleReturn("body", "v1");
            //return BadRequest();
            //return NotFound();
            //return Ok(model);
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
    }
}