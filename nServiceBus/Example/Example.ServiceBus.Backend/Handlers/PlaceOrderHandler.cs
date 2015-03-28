using System;
using System.Diagnostics.Eventing.Reader;
using Example.ServiceBus.Backend.DTO;
using Example.ServiceBus.BillingContracts;
using Example.ServiceBus.Contracts;
using NServiceBus;
using NServiceBus.RavenDB;
using Raven.Client.Document;


namespace Example.ServiceBus.Backend.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<CustomerOrder>
    {
        private readonly IBus _bus;

        public PlaceOrderHandler(IBus bus)
        {
          _bus = bus;
        }

        public void Handle(CustomerOrder message)
        {
            Console.WriteLine("CustomerOrder Received - " + message.OrderId);

            //NServiceBus.RavenDB.ConfigureRavenPersistence.RavenDBStorage()

            /*try
            {
                var store = new DocumentStore() { Url = "http://localhost:8080", DefaultDatabase = "TestDatabase"};

                store.Initialize();
                store.JsonRequestFactory.DisableRequestCompression = true;

                using (var session = store.OpenSession())
                {
                    session.Store(new CustomerOrderDto() { CustomerName = "ABC" });
                    session.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            _bus.Send(new ChargeCard() { Amount = 100, CustomerId = message.CustomerId });
        }
    }

    /* 
    public class PlaceOrderHandler : IHandleMessages<CustomerOrderDto>
    {
        public void Handle(CustomerOrderDto message)
        {
            throw new Exception("Message Error");
            Console.WriteLine("CustomerOrderDto - " + message.OrderId);
        }
    }
    */

    /*
    //Distrubuted transaction Example
      
    public class PlaceOrderHandler : IHandleMessages<CustomerOrderDto>
    {
        public void Handle(CustomerOrderDto message)
        {
            var store = new DocumentStore
            {Url = "http://localhost:8080"}
     
            store.Initialize();
            store.JsonRequestFactory.DisableRequestCompression = true;
      
            using (var session = store.OpenSession())
            {
                session.Store(new OrderDTO{ OrderId = message.OrderId});
     
                session.SaveChanges(); 
            }
     
            throw new Exception("Message Error");
            Console.WriteLine("CustomerOrderDto - " + message.OrderId);
        }
    }
    */
}
