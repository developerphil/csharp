using Example.ServiceBus.Backend.Handlers;
using NServiceBus;

namespace Example.ServiceBus.Backend
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(Order order)
        {
            //order.Specify(First<Handler>.Then<HandlerOrder>().AndThen<HandlerOrder2>());
            order.Specify(new[] { typeof(Authentication), typeof(Handler), typeof(PlaceOrderHandler) });
        }

    }
}
