using System;
using Example.ServiceBus.BillingContracts;
using NServiceBus;

namespace Example.ServiceBus.Billing
{
    public class ChargeCreditCardHandler : IHandleMessages<ChargeCard>
    {
        private readonly IBus _bus;

        public ChargeCreditCardHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(ChargeCard message)
        {
            Console.WriteLine("Charging card third party");

            _bus.Reply(new CardCharged { CustomerId = message.CustomerId, Receipt = Guid.NewGuid() });
        }
    }
}
