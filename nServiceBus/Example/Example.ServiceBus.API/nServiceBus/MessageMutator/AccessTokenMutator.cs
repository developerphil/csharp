using NServiceBus;
using NServiceBus.MessageMutator;

namespace Example.ServiceBus.API.nServiceBus.MessageMutator
{
    public class AccessTokenMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            transportMessage.Headers["access_token"] = "pass";
            transportMessage.Headers["infrastructure"] = "infrastructure";
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AccessTokenMutator>(DependencyLifecycle.InstancePerCall);
        }

    }
}