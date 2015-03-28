using System;
using NServiceBus;
using NServiceBus.Persistence.Raven;
using NServiceBus.RavenDB;
using NServiceBus.UnitOfWork;
using Raven.Client;
using Raven.Client.Document;

namespace Example.ServiceBus.Backend
{
    public class Bootstrap : INeedInitialization
    {
        public void Init()
        {

            Console.WriteLine("Initialise");
            //Dependency injection setup in here

            //Built in dependency injection

            //Configure.Instance.RavenPersistence("RavenDB", "Example.ServiceBus.Backend");
           /*Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(
                () =>
                {
                    // Initialize the data store, point url to where db is listening
                    var store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "Example.ServiceBus.Backend" };
                    store.Initialize();
                    store.JsonRequestFactory.DisableRequestCompression = true;
                    return store;
                }
                    , DependencyLifecycle.SingleInstance);

            Configure.Instance.Configurer.ConfigureComponent(() => Configure.Instance.Builder.Build<IDocumentStore>().OpenSession(), DependencyLifecycle.InstancePerUnitOfWork);

            Configure.Instance.Configurer.ConfigureComponent<DatabaseWork>(DependencyLifecycle.InstancePerUnitOfWork);*/
        }
    }

}
