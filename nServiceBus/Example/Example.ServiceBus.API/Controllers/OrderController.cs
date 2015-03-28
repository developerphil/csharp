using System;
using System.Collections.Generic;
using System.Web.Http;
using Example.ServiceBus.Contracts;
using NServiceBus;

namespace Example.ServiceBus.API.Controllers
{
    public class OrderController : ApiController
    {
        public OrderController()
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var order = new CustomerOrder() {CustomerId = Guid.NewGuid(), OrderId = Guid.NewGuid()};
            order.SetHeader("message-type", "orderMessage");

            //One way messaging
            nServiceBus.ServiceBus.Bus.Send(order);

            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

            nServiceBus.ServiceBus.Bus.Send(new CustomerOrder() { CustomerId = Guid.NewGuid(), OrderId = Guid.NewGuid() });
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}