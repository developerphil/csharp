using System.Web.Http;
using WebAPI.ActionResult;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly IExampleRepository _exampleRepository;

        public BaseApiController(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        protected IExampleRepository ExampleRepository
        {
            get { return _exampleRepository; }
        }

        protected IHttpActionResult ExampleReturn<T>(T body, string version) where T : class
        {
            return new ExampleActionResult<T>(Request, version, body);
        }
    }
}
