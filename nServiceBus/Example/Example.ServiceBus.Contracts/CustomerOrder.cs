using System;
using NServiceBus;

namespace Example.ServiceBus.Contracts
{
    //[TimeToBeReceived("00:00:10")]
    public class CustomerOrder : IMessage
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
