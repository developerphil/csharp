using NServiceBus;
using NServiceBus.Installation.Environments;

namespace Example.Backoffice
{
    public static class ServiceBus
    {
        public static IBus Bus { get; private set; }

        public static void Init()
        {
            if (Bus != null)
                return;

            lock (typeof(ServiceBus))
            {
                if (Bus != null)
                    return;

                Configure.Serialization.Xml();

                Bus = Configure.With()
                    .DefaultBuilder()
                    .UseTransport<Msmq>()
                    .UnicastBus()
                    .CreateBus()
                    .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());

                Bus.OutgoingHeaders["access_token"] = "pass";
            }
        }

    }
}
