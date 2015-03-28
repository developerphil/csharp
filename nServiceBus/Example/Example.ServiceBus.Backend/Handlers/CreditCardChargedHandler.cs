using System;
using Example.ServiceBus.BillingContracts;
using NServiceBus;

namespace Example.ServiceBus.Backend.Handlers
{
    public class CreditCardChargedHandler : IHandleMessages<CardCharged>
    {
        public void Handle(CardCharged message)
        {
            Console.WriteLine("Customer " + message.CustomerId + " Receipt " + message.Receipt);
        }
    }
}
