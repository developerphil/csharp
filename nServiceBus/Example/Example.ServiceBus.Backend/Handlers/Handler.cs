using System;
using NServiceBus;

namespace Example.ServiceBus.Backend.Handlers
{
    public class Handler : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
            Console.WriteLine("Message id - " + Bus.CurrentMessageContext.Id);
            Console.WriteLine("Reply To Address - " + Bus.CurrentMessageContext.ReplyToAddress);
            Console.WriteLine("Header Count - " + Bus.CurrentMessageContext.Headers.Count);

            Console.WriteLine("This is handled for every message e.g. validation, authentication");
        }
    }
}