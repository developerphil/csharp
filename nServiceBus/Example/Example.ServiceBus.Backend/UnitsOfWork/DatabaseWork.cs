using System;
using NServiceBus.UnitOfWork;
using Raven.Client;

namespace Example.ServiceBus.Backend.UnitsOfWork
{
    ///Runs everytime when a message is processed. e.g. like a HttpModule
    public class DatabaseWork : IManageUnitsOfWork
    {
        public IDocumentSession Session { get; set; }

        public void Begin()
        {
            Console.WriteLine("Database work start runs everytime when a message is processed. e.g. like a HttpModule");
        }

        public void End(Exception ex = null)
        {
            Console.WriteLine("Database work end runs everytime when a message is processed. e.g. like a HttpModule");
        
            if (ex == null)
            {
                //Session.SaveChanges();
            }
        }
    }
}