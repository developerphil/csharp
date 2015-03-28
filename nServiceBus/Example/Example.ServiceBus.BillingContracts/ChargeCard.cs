using System;
using NServiceBus;

namespace Example.ServiceBus.BillingContracts
{
    public class ChargeCard : IMessage
    {
        public Guid CustomerId { get; set; }
        public int Amount { get; set; }
    }
}
