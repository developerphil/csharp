using System;
using NServiceBus;

namespace Example.ServiceBus.BillingContracts
{
    public class CardCharged : IMessage
    {
        public Guid CustomerId { get; set; }
        public Guid Receipt { get; set; }
    }
}