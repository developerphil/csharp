using System;
using NServiceBus;

namespace Example.ServiceBus.Backend.Handlers
{
    public class Authentication : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
            var token = message.GetHeader("access_token");

           // if (token != "pass")
           // {
           //    Console.WriteLine("User not authenticated");
           //     Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
           //     return;
           // }
                
            Console.WriteLine("User authenticated");
        }
    }
}