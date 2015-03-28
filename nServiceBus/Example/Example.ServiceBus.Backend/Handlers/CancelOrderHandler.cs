using System;
using Example.ServiceBus.Contracts;
using NServiceBus;

namespace Example.ServiceBus.Backend.Handlers
{
    public class CancelOrderHandler : IHandleMessages<CancelOrder>
    {
        public IBus Bus { get; set; }

        public void Handle(CancelOrder message)
        {
            Console.WriteLine("Cancel CustomerOrderDto - " + message.OrderId);

            Bus.Return(Status.Success);
        }
    }
}